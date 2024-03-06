using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusTicketProject.Models;
using BusTicketProject.Services;
using DtoLayer.TicketDto;
using EntitiyLayer.Concrete;
using JWTIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITicketService _ticketService;
        private readonly IVoyageService _voyageService;
        public AuthController(IAuthService authService, ITicketService ticketService, IVoyageService voyageService)
        {
            _authService = authService;
            _ticketService = ticketService;
            _voyageService = voyageService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            return Ok(await _authService.RegisteUser(user));
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var loginResult = await _authService.Login(user);
            if (loginResult)
            {
                var tokenString = await _authService.GenerateTokenStringAsync(user);
                var username = await _authService.GetUsernameFromToken(tokenString);
                var x = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);


                return Ok(new { Token = tokenString, Username = username, id = x });
            }
            return BadRequest();
        }

        //    [Authorize]
     
        [HttpGet("ValidateToken")]
        public async Task<IActionResult> ValidateToken()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (await _authService.ValidateToken(token))
            {
                var x = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);
                var y = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.Email);

                return Ok(new { NameIdentifier = x.Value, Email = y.Value });
            }
            return Unauthorized();
        }

      //  [Authorize]

        [HttpPost("BuyTicket")]
        public IActionResult BuyTicket(BuyTicketDto buyTicketDto)
        {
            
            // gelince vue dan gönder appuserıd yi

            Ticket ticket = new Ticket
            {
                TicketPrice = buyTicketDto.TicketPrice,
                UserID = 1,
                SeatNumber = buyTicketDto.SeatNumber,
                TicketStatus = buyTicketDto.TicketStatus,
                VoyageID = buyTicketDto.VoyageID,
                AppUserID = buyTicketDto.AppUserID,
               UserStartingPlace =buyTicketDto.UserStartingPlace,
               UserDestination = buyTicketDto.UserDestination
            };
            _ticketService.TAdd(ticket);
            return Ok(ticket);
        }

         [Authorize]
        [HttpGet("GetUserTicket")]
        public IActionResult GetUserTicket()
        {
            var userId = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var tickets =  _ticketService.GetUserTicket(int.Parse(userId));
            return Ok(tickets);
        }

        [Authorize]
        [HttpGet("GetCompanyVoyage")]
        public IActionResult GetCompanyVoyage()
        {
            var userId = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var voyages = _voyageService.GetCompanyVoyages(int.Parse(userId));
            return Ok(voyages);

        }
    }
}
