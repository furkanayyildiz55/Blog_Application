using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentUserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz");
            RuleFor(x => x.CommentContent).NotEmpty().WithMessage("Lütfen içeriğini doldurunuz");
        }
    }
}
