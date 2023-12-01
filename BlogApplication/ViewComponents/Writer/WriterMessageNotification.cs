using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository()); 

        public IViewComponentResult Invoke()
        {
            var values = message2Manager.GetInboxListByWriter(1);
            return View(values);
        }
    }
}
