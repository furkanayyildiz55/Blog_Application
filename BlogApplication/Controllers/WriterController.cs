using BlogApplication.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	[Authorize]
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Profile()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writer = writerManager.GetByID(1);
			return View(writer);
		}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
			WriterValidator validator = new WriterValidator();
			ValidationResult result = validator.Validate(writer);
			if (result.IsValid)
			{
				writerManager.Update(writer);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View(writer);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
			Writer writer =new Writer();
			if(addProfileImage.WriterImage != null)
			{
				var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				addProfileImage.WriterImage.CopyTo(stream);

				writer.WriterImage = newImageName;
			}
			writer.WriterMail = addProfileImage.WriterMail;
			writer.WriterName = addProfileImage.WriterName;
			writer.WriterPassword = addProfileImage.WriterPassword;
			writer.WriterStatus = true;
			writer.WriterAbout = writer.WriterAbout;
			writerManager.Add(writer);


            return RedirectToAction("Index","Dashboard");
        }
    }
}
