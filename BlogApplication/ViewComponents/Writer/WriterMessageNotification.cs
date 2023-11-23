using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
