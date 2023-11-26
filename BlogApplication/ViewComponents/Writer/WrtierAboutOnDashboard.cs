using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Writer
{

	public class WrtierAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new  WriterManager(new EfWriterRepository());
		public IViewComponentResult Invoke()
		{
			var values = writerManager.GetWriterByID(1);
			return View(values);
		}

	}
}
