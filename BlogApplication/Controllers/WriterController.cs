using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
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
		public IActionResult WriterEditProfile()
		{
			var writer = writerManager.GetByID(1);
			return View(writer);
		}
	}
}
