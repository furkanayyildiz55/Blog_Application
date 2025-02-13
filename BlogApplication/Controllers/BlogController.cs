﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApplication.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
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
            Context c = new Context();
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = bm.GetBlogListWithCategoryByWriter(writerId);
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


            ViewBag.CategoryItem = CategoryItem();
            return View();
        }



        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.WriterID = writerId;
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

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var Blog = bm.GetByID(id);
            ViewBag.CategoryItem = CategoryItem();
            return View(Blog);
        }

        [HttpPost]
		public IActionResult EditBlog(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                bm.Update(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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



        private List<SelectListItem> CategoryItem()
        {
            List<Category> categories = cm.GetList();
            List<SelectListItem> SelectListItem = new List<SelectListItem>();
            foreach (var item in categories)
            {
                SelectListItem listItem = new SelectListItem(text: item.CategoryName, value: item.CategoryID.ToString());
                SelectListItem.Add(listItem);
            }
            return SelectListItem;
        }
    }
}
