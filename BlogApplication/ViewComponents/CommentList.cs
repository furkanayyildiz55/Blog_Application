using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
