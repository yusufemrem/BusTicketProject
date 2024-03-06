using BusTicketProject.CQRS.Queries.GetAllTicketQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketMediatRController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllTicket")]
        public async Task<IActionResult> GetAllTicket()
        {
            var values = await _mediator.Send(new GetAllTicketQuery());
            return Ok(values);
        }

    }
}
