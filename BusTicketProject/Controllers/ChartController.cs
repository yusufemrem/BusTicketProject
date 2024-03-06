using BusTicketProject.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        [HttpGet("CompanyChart2")]
        public IActionResult CompanyChart2()
        {
            List<VoyageModel> voyageModels = new List<VoyageModel>();
            using (var c = new Context())
            {
                voyageModels = c.Voyages.Select(x => new VoyageModel
                {
                    CompanyID = x.CompanyID
                }).ToList();
            }
            return new JsonResult(new { jsonlist = voyageModels });
        }

        [HttpGet("CompanyChart")]
        public IActionResult CompanyChart()
        {
            List<CompanyModel> list = new List<CompanyModel>();

            list.Add(new CompanyModel
            {

                companyname = "Emrem",
                companycount = 14,
            });
            list.Add(new CompanyModel
            {
                companyname = "Kamil Koç",
                companycount = 14,
            });
            list.Add(new CompanyModel
            {
                companyname = "Pamukkale",
                companycount = 5,
            });
            return new JsonResult(new { jsonlist = list });
        }

    }
}
