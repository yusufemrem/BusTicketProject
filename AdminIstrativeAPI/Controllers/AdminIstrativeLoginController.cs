
using BusTicketProject.Models;
using BusTicketProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminIstrativeLoginController : ControllerBase
    {
        private readonly IAdminIstrativeService _ıAdminIstrativeService;
      
        public AdminIstrativeLoginController(IAdminIstrativeService ıAdminIstrativeService)
        {
            _ıAdminIstrativeService = ıAdminIstrativeService;

        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterAdminIstrative(LoginUser user)
        {
            return Ok(await _ıAdminIstrativeService.RegisteUser(user));
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var loginResult = await _ıAdminIstrativeService.Login(user);
            if (loginResult)
            {
                var tokenString = await _ıAdminIstrativeService.GenerateTokenStringAsync(user);
                var username = await _ıAdminIstrativeService.GetUsernameFromToken(tokenString);
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
            if (await _ıAdminIstrativeService.ValidateToken(token))
            {
                var x = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);
                var y = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.Email);

                return Ok(new { NameIdentifier = x.Value, Email = y.Value });
            }
            return Unauthorized();
        }

   
    }
}
