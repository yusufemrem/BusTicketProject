using DtoLayer.MessageDto;
using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<SendMessageDto>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageDetail).MinimumLength(3).NotEmpty().WithMessage("Mesaj Bölümü En Az 3 Karakterden Oluşmalıdır!");
        }
    }
}
