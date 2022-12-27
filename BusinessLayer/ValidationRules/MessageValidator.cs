using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcının Mail Adresi Boş Olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Olamaz.");

            RuleFor(x => x.ReceiverMail).MinimumLength(11).WithMessage("Lütfen En Az 11 Karakter Giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz");


            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen En Fazla 100 Karakter Giriniz");
        }
    }
}
