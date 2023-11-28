using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	public class NotificationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
