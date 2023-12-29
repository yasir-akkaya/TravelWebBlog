using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogWeb.Entity;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Entity.Interfaces;
using TravelBlogWeb.Models;



namespace TravelBlogWeb.Controllers
{
    public class SingleBlogController : Controller
    {
        BlogPostProcess blogPostProcess = new BlogPostProcess();
        CommentProcess commentProcess = new CommentProcess();
        PartialProcess partialProcess = new PartialProcess();
        BlogLikeProcess blogLikeProcess = new BlogLikeProcess();
        DataContext db = new DataContext();

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
            ViewData["currentBlogId"] = id;
            var blog = blogPostProcess.Get(id);
            var populars = partialProcess.GetPopulars();
            var latests = partialProcess.GetLatests();
            ViewBag.populars = populars;
            ViewBag.latests = latests;
            ViewBag.blogId = id;
            ViewBag.likeCount = blogLikeProcess.GetBlogCount(id);
            int userId = Convert.ToInt32(HttpContext.Session["userId"]);


            var likeState = db.BlogLikes.FirstOrDefault(like => like.BlogPostId == id && like.UserId == userId);

            bool isLiked;
            if (likeState == null)
            {
                isLiked = false;
            }
            else
            {
                isLiked = true;

            }
            ViewBag.isLiked = isLiked;

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
                BlogPostId = blogId
            };

            commentProcess.Add(newComment);
            return View();
        }

        [HttpPost]

        public ActionResult Like()
        {
            int currentId = Convert.ToInt32(Request.Form["likeblogId"]);

            BlogLike newLike = new BlogLike
            {
                UserId = Convert.ToInt32(HttpContext.Session["userId"]),
                BlogPostId = currentId
            };

            blogLikeProcess.Add(newLike);

            return RedirectToAction("Index", "Cities");

        }
        [HttpPost]
        public ActionResult Dislike()
        {
            int currentId = Convert.ToInt32(Request.Form["likeblogId"]);
            int userId = Convert.ToInt32(HttpContext.Session["userId"]);
            var dislikedLike = db.BlogLikes.FirstOrDefault(x => x.BlogPostId == currentId && x.UserId ==userId);

            int dislikedId = Convert.ToInt32(dislikedLike.Id);
            string result = blogLikeProcess.Dislike(dislikedId);

            ViewBag.ResultMessage = result;

            return RedirectToAction("Index", "Cities");
        }


    }
}
