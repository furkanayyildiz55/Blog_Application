using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());

		public IActionResult Index()
		{
			var aboutList = aboutManager.GetList();
			return View(aboutList);
		}

		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();	
		}
	}
}
