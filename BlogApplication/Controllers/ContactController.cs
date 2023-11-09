using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
	public class ContactController : Controller
	{
		ContactManager contactManager = new ContactManager(new EfContactRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContatcDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			contactManager.ContactAdd(contact);	
			return View();
		}
	}
}
