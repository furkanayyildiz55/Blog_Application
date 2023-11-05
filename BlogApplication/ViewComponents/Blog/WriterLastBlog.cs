using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager BlogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = BlogManager.GetBlogListWitWriter(1);
            return View(values);    
        }

    }
}
