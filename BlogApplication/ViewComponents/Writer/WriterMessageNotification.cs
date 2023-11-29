using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository()); 

        public IViewComponentResult Invoke()
        {
            string writerMail = "test@test.com";
            var values = messageManager.GetInboxListByWriter(writerMail);
            return View(values);
        }
    }
}
