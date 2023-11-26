using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            ViewBag.BlogCount = bm.GetBlogCount(-1);
            ViewBag.WriterBlogCount = bm.GetBlogCount(1);

            return View();
        }
    }
}
