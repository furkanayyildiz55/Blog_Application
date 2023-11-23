using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
