using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{

	public class WrtierAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new  WriterManager(new EfWriterRepository());


        public IViewComponentResult Invoke()
		{
            Context c = new Context();

            var userMail = User.Identity.Name;

			var writerId = c.Writers.Where( x => x.WriterMail == userMail ).Select(y=>y.WriterID).FirstOrDefault();
			var values = writerManager.GetWriterByID(writerId);

			return View(values);
		}

	}
}
