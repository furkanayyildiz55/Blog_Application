using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApplication.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Index (Writer writer)
		{

            Context c = new Context();
            var data = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (data != null) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , writer.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
		}
	}
}
