using DtoLayer.RegisterDto;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(); // Consider returning a BadRequest result if ModelState is not valid
            }

            var appUser = new AppUser
            {
                Name = createUserDto.Name,
                Email = createUserDto.Mail,
                Surname = createUserDto.Surname,
                UserName = createUserDto.Username,
                Password = createUserDto.Password,
                ConfirmPassword = createUserDto.ConfirmPassword
            };

            var result = await _userManager.CreateAsync(appUser, createUserDto.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            // Log the errors for debugging purposes
            foreach (var error in result.Errors)
            {
                // You may log or print these errors for debugging purposes
                Console.WriteLine($"Error: {error.Code}, Description: {error.Description}");
            }

            return Ok(); // Consider returning a more meaningful response for failed registration
        }
    }
}
