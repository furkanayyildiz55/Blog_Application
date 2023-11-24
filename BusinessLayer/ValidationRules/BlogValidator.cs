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
			RuleFor(x => x.BlogTitle)
				.NotEmpty().WithMessage("Lütfen blog başlığı giriniz")
				.MinimumLength(1).WithMessage("Blog başlığı en az 1 karakter olmalıdır")
				.MaximumLength(55).WithMessage("Blog başlığı en fazla 55 karakter olabilir");

			RuleFor(x => x.BlogContent)
				.NotEmpty().WithMessage("Lütfen blog içeriği giriniz")
				.MinimumLength(1).WithMessage("Blog içeriği en az 1 karakter olmalıdır")
				.MaximumLength(15000).WithMessage("Blog içeriği en fazla 15000 karakter olabilir");

            //RuleFor(x => x.BlogCreateDate)
            //	.NotEmpty().WithMessage("Lütfen blog tarihi giriniz");

            RuleFor(x => x.CategoryID)
			.NotNull().WithMessage("Lütfen blog için bir kategori seçiniz");

            RuleFor(x => x.CategoryID)
				 .NotEmpty().WithMessage("Lütfen blog için bir kategori seçiniz");


        }
	}
}
