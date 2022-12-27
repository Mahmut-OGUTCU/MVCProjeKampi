using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Boş Olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Başlığı Boş Olamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Olamaz");

            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli Posta Adresi Giriniz");

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");
            RuleFor(x => x.WriterTitle).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");

            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }
    }
}
