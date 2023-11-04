using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Lütfen yazar adını giriniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Lütfen bir mail adresi giriniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Lütfen şifre giriniz");
        }
    }
}
