using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager WriterManager = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsRecorded = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);

            if (validationResult.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Test About";
                WriterManager.WriterAdd(writer);
                ViewBag.IsRecorded = true;
                ModelState.Clear();
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.IsRecorded = false;
                //ViewBag.KeyValuePair = new KeyValuePair<int, string>(1, "asd");
            }
            return View();
        }
    }
}
