using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	[AllowAnonymous]
	public class NotificationController : Controller
	{
		NotificationManager NotificationManager = new NotificationManager(new EfNotificationRepository());

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AllNotification()
		{
			var values = NotificationManager.GetList();
			return View(values);
		}
	}
}
