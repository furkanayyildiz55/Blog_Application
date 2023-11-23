using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	[Authorize]
	public class WriterController : Controller
	{
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
    }
}
