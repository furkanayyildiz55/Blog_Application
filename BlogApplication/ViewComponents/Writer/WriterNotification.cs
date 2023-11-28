using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
		NotificationManager NotificationManager = new NotificationManager(new EfNotificationRepository());

		public IViewComponentResult Invoke()
		{
			var values = NotificationManager.GetList();
			return View(values);
		}
	}
}
