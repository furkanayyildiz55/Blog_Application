using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Blog
{
	public class BlogListDashboard : ViewComponent
	{

		BlogManager BlogManager = new BlogManager(new EfBlogRepository());


		public IViewComponentResult Invoke()
		{
			var values = BlogManager.GetBlogListWithCategory();
			return View(values);
		}

	}
}
