using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
