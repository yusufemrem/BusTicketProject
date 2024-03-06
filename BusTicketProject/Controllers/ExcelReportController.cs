using BusinessLayer.Abstract;
using BusTicketProject.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelReportController : ControllerBase
    {
        private readonly IExcelService _excelService;

        public ExcelReportController(IExcelService excelService)
        {
            _excelService = excelService;
        }
        [HttpGet("VoyageList")]

        public List<VoyageModel> VoyageList()
        {
            List<VoyageModel> voyageModels = new List<VoyageModel>();
            using (var c = new Context())
            {
                voyageModels = c.Voyages.Select(x => new VoyageModel
                {
                    StartingPlace = x.StartingPlace,
                    Destination = x.Destination,
                    StartingDate = x.StartingDate,
                    DestinationDate = x.DestinationDate,
                    SeatCapacity = x.SeatCapacity,
                    TicketPrice = x.TicketPrice
                }).ToList();
            }
            return voyageModels;
        }
        //[HttpGet("StaticExcelReport")]
        //public IActionResult StaticExcelReport()
        //{
        //    return File(_excelService.ExcelList(StaffList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        //}
        [HttpGet("VoyageExcelReport")]

        public IActionResult VoyageExcelReport()
        {
            using (var workBook = new ClosedXML.Excel.XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Sefer Listesi");
                workSheet.Cell(1, 1).Value = "Başlangıç Noktası";
                workSheet.Cell(1, 2).Value = "Bitiş Noktası";
                workSheet.Cell(1, 3).Value = "Başlangıç Tarihi";
                workSheet.Cell(1, 4).Value = "Bitiş Tarihi";
                workSheet.Cell(1, 5).Value = "Koltuk Kapasitesi";
                workSheet.Cell(1, 6).Value = "Bilet Ücreti";

                int rowCount = 2;
                foreach (var item in VoyageList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.StartingPlace;
                    workSheet.Cell(rowCount, 2).Value = item.Destination;
                    workSheet.Cell(rowCount, 3).Value = item.StartingDate;
                    workSheet.Cell(rowCount, 4).Value = item.DestinationDate;
                    workSheet.Cell(rowCount, 5).Value = item.SeatCapacity;
                    workSheet.Cell(rowCount, 6).Value = item.TicketPrice;

                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }

    }
}
