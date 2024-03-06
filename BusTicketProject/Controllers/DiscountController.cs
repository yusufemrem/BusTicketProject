using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("DiscountCupon")]
        public IActionResult DiscountCupon(DiscountCodeDto discountCodeDto)
        {
            Random rnd = new Random();
            string[] characters = { "A", "B", "C", "D" };
            int k1, k2, k3; 
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + characters[k1] + s2 + characters[k2] + s3 + characters[k3];

            Discount discount = new Discount
            {
                DiscountName = kod,
                DiscountAmount = discountCodeDto.DiscountAmount
            };
            _discountService.TAdd(discount);
            return Ok();

        }
        [HttpGet("AllCupon")]
        public IActionResult AllCupon()
        {
           var values = _discountService.GetList();
            return Ok(values);
        }
        [HttpDelete("DeleteCupon/{id}")]
        public IActionResult DeleteCupon(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok();
        }
    }
}
