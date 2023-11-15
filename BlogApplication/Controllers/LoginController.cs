using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
        [HttpPost]
		public IActionResult Index(Writer writer)
		{
            Context c = new Context();
            var data = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail);
            if (data != null) 
            {
                HttpContext.Session.SetString("username", writer.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
		}
	}
}
