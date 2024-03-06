using BusinessLayer.Abstract;
using DtoLayer.VoyageDto;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyageController : ControllerBase
    {
        private IVoyageService _voyageService;

        public VoyageController(IVoyageService voyageService)
        {
            _voyageService = voyageService;
        }
        [HttpGet("AllVoyage")]
        public IActionResult AllVoyage()
        {
            var values = _voyageService.GetList();
            return Ok(values);
        }
        [HttpPost("AddVoyage")]
        public IActionResult AddVoyage(CreateVoyageDto createVoyageDto)
        {
            Voyage voyage = new Voyage
            {
                StartingPlace = createVoyageDto.StartingPlace,
                Destination = createVoyageDto.Destination,
                StartingDate = createVoyageDto.StartingDate,
                DestinationDate = createVoyageDto.DestinationDate,
                CompanyID = createVoyageDto.CompanyID,
                SeatCapacity = createVoyageDto.SeatCapacity,
                TicketPrice = createVoyageDto.TicketPrice,
                AppUserID = createVoyageDto.AppUserID
                
            };

            _voyageService.TAdd(voyage);
            return Ok();
        }
        [HttpDelete("DeleteVoyage/{id}")]
        public IActionResult DeleteVoyage(int id)
        {
            var values = _voyageService.TGetById(id);
            _voyageService.TDelete(values);
            return Ok();
        }
    }

}
