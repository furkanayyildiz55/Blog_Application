using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager BlogManager = new BlogManager(new EfBlogRepository());


		public IViewComponentResult Invoke()
		{
			var values = BlogManager.GetLast3Blog();
			return View(values);
		}
		                         
	}
}
