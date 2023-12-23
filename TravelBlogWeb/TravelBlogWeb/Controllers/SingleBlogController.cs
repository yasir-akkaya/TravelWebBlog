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
        PartialProcess partialProcess=new PartialProcess();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowBlog(int id)
        {
            //List<object> blogAndComments = new List<object>();
            //blogAndComments.Add(blogComments);
            //blogAndComments.Add(blog);

            var blogComments = commentProcess.GetBlogComments(id);
            int commentsCount = blogComments.Count();
            ViewData["commentCount"] = commentsCount;
            ViewData["Comments"]=blogComments;
            var blog = blogPostProcess.Get(id);
            var populars = partialProcess.GetPopulars();
            var latests = partialProcess.GetLatests();
            ViewBag.populars = populars;
            ViewBag.latests = latests;
            return View(blog);
        }
    }
}
