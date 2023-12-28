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
    public class PanelController : Controller
    {
        DataContext db = new DataContext();
        UserProcess userProcess = new UserProcess();
        BlogPostProcess blogPostProcess = new BlogPostProcess();
        CommentProcess commentProcess = new CommentProcess();
        BlogLikeProcess blogLikeProcess = new BlogLikeProcess();

        public ActionResult Index()
        {
            int userId = (int)(HttpContext.Session["userId"]);
            var userProvider = new RoleSecurityProvider();
            if (userProvider.IsUserAdmin(userId))
            {
                PanelHomeModel model = new PanelHomeModel();
                model.UserCount = userProcess.GetAll().Count();
                model.BlogCount = blogPostProcess.GetAll().Count();
                model.CommentCount = commentProcess.GetAll().Count();
                model.ApprovedComments = commentProcess.GetApproved();
                model.PendingComments = commentProcess.GetPendings();
                model.ApprovedCommentsCount = commentProcess.GetApproved().Count();
                model.PendingCommentsCount = commentProcess.GetPendings().Count();
                model.LikesCount = blogLikeProcess.GetAll().Count();
                return View(model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        //public ActionResult Likes()
        //{

        //    return true;
        //}
    }
}