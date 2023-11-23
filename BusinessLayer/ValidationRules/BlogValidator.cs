using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            //RuleFor(x => x.CommentUserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz");
            //RuleFor(x => x.CommentContent).NotEmpty().WithMessage("Lütfen içeriğini doldurunuz");
        }
    }
}
