using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
