using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogWeb.Entity;
using TravelBlogWeb.Models;



namespace TravelBlogWeb.Controllers
{
    public class SingleBlogController : Controller
    {
        BlogPostProcess blogPostProcess = new BlogPostProcess();
        CommentProcess commentProcess = new CommentProcess();
        PartialProcess partialProcess = new PartialProcess();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowBlog(int id)
        {

            var blogComments = commentProcess.GetBlogComments(id);
            int commentsCount = blogComments.Count();
            ViewData["commentCount"] = commentsCount;
            ViewData["Comments"] = blogComments;
            var blog = blogPostProcess.Get(id);
            var populars = partialProcess.GetPopulars();
            var latests = partialProcess.GetLatests();
            ViewBag.populars = populars;
            ViewBag.latests = latests;
            ViewBag.blogId = id;
            return View(blog);
        }





        [HttpPost]
        public ActionResult AddComment()
        {
            string commentText = Request.Form["commentText"];
            int blogId = Convert.ToInt32(Request.Form["blogId"]);
            BlogComment newComment = new BlogComment
            {
                Comment = commentText,
                CreationDate = DateTime.Now,
                UserId = Convert.ToInt32(HttpContext.Session["userId"]),
                IsActive = false,
                BlogPostId= blogId
            };

            commentProcess.Add(newComment);
            return View();  
        }


    }
}
