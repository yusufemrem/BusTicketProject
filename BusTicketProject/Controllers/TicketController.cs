using BusinessLayer.Abstract;
using DtoLayer.TicketDto;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("BuyTicket")]
        public IActionResult BuyTicket(BuyTicketDto buyTicketDto)
        {
            Ticket ticket = new Ticket
            {
                TicketPrice = buyTicketDto.TicketPrice,
                UserID = 1,
                SeatNumber = buyTicketDto.SeatNumber,
                TicketStatus = buyTicketDto.TicketStatus,
                VoyageID = buyTicketDto.VoyageID,
                AppUserID = buyTicketDto.AppUserID,
                UserStartingPlace = buyTicketDto.UserStartingPlace,
                UserDestination = buyTicketDto.UserDestination
            };
            _ticketService.TAdd(ticket);
            return Ok(ticket);
        }

        [HttpGet("TicketDetail")]
        public IActionResult TicketDetail()
        {
            var values = _ticketService.GetList();
            return Ok(values);
        }

        [HttpGet("GetByTicket/{id}")]
        public IActionResult GetByTicket(int id)
        {
            var values = _ticketService.TGetById(id);
            return Ok(values);
        }

    }
}
