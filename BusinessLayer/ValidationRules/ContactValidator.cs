using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");

            //RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }
    }
}
