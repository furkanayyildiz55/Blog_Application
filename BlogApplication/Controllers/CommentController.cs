using BlogApplication.DTO;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApplication.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartiaAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult PartiaAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //TODO:yorum durumu, daha sonradan false yapılıp admin kontrolünde olacak
            comment.CommentStatus = true;


            CommentValidator validationRules = new CommentValidator();
            ValidationResult validationResult = validationRules.Validate(comment);

            if (validationResult.IsValid)
            {
                commentManager.CommentAdd(comment);
                return Json(new { status = true, message = "Yorumunuz eklendi..." });
            }
            else
            {
                AjaxResultDTO ajaxResultDTO = new AjaxResultDTO();
                ajaxResultDTO.status = false;

               
                foreach (var item in validationResult.Errors)
                {
                    ResultMessage resultMessage = new ResultMessage(item.PropertyName, item.ErrorMessage); 
                }

                string jsonData = JsonConvert.SerializeObject(ajaxResultDTO);
                //return Content(jsonData, "application/json");

            }


        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
