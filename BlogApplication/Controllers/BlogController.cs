using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApplication.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult TestPage()
        {
            return View();
        }

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetBlogListWithCategoryByWriter(1);
            return View(values);
        }

        public IActionResult BlogDelete(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.Delete(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<Category> categories = cm.GetList();
            List<SelectListItem> SelectListItem = new List<SelectListItem>();
            foreach (var item in categories)
            {
                SelectListItem listItem = new SelectListItem(text: item.CategoryName, value: item.CategoryID.ToString());
                SelectListItem.Add(listItem);
            }
            ViewBag.CategoryItem = SelectListItem;
            return View();
        }


        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.WriterID = 1;
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Now;
                bm.Add(blog);
                return RedirectToAction("BlogListByWriter" , "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
