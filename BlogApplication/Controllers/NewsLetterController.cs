using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }


        [HttpPost]
        public JsonResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;

            NewsLetterValidator validationRules = new NewsLetterValidator();
            ValidationResult validationResult = validationRules.Validate(newsLetter);

            if (validationResult.IsValid)
            {
                newsLetterManager.AddNewsLetter(newsLetter);
                return Json(new { status = true, message = "Bültene abone oldunuz !" });
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    if (item.PropertyName == "Mail")
                    {
                        return Json(new { status = false, message = item.ErrorMessage });
                    }
                }
                return null;
            }

        }
    }
}
