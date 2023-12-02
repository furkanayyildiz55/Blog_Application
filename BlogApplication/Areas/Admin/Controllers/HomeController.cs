using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
