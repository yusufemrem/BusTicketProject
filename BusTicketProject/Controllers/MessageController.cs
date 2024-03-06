using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DtoLayer.MessageDto;
using EntitiyLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BusTicketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(SendMessageDto sendMessageDto)
        {
            MessageValidator wv = new MessageValidator();
            ValidationResult results = wv.Validate(sendMessageDto);
            if (results.IsValid)
            {
                Message message = new Message
                {
                    MessageDetails = sendMessageDto.MessageDetail,
                    CompanyID = sendMessageDto.CompanyID,
                };
                _messageService.TAdd(message);
                return Ok();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return Ok();

        }
        [HttpGet("AllMessage")]
        public IActionResult AllMessage()
        {
            var values = _messageService.GetList();
            return Ok(values);
        }
    }
}
