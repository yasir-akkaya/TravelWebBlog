using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public ActionResult Likes()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            if (userProvider.IsUserAdmin(userId))
            {
                var allLikes = blogLikeProcess.GetAll();

                return View(allLikes);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        public ActionResult PendingComments()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            if (userProvider.IsUserAdmin(userId))
            {
                var pendingComments = commentProcess.GetPendings();

                return View(pendingComments);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        [HttpPost]
        public ActionResult ApproveComment()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            int commentId = Convert.ToInt32(Request.Form["commentId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                BlogComment approvedComment = new BlogComment
                {
                    IsActive = true
                };

                commentProcess.Update(approvedComment, commentId);
                return RedirectToAction("pendingComments");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        public ActionResult ApprovedComments()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            if (userProvider.IsUserAdmin(userId))
            {
                var pendingComments = commentProcess.GetApproved();

                return View(pendingComments);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }



        [HttpPost]
        public ActionResult DeleteComment()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            int commentId = Convert.ToInt32(Request.Form["commentId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                commentProcess.Delete(commentId);
                return RedirectToAction("ApprovedComments");

            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }
        [HttpPost]
        public ActionResult HardDeleteComment()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            int commentId = Convert.ToInt32(Request.Form["commentId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                BlogComment blogCommentToDelete = db.BlogComments.Find(commentId);
                db.BlogComments.Remove(blogCommentToDelete);
                db.SaveChanges();

                return RedirectToAction("pendingComments");

            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }
        public ActionResult BlogsPanel()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                List<BlogPost> posts = new List<BlogPost>();
                posts = blogPostProcess.GetAll();
                return View(posts);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }
        [HttpPost]
        public ActionResult DeleteBlog()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            int blogId = Convert.ToInt32(Request.Form["blogId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                blogLikeProcess.Delete(blogId);
                blogPostProcess.Delete(blogId);
                return RedirectToAction("BlogsPanel");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        public ActionResult UsersPanel()
        {
            var userProvider = new RoleSecurityProvider();

            int userId = (int)(HttpContext.Session["userId"]);

            if (userProvider.IsUserAdmin(userId))
            {
                List<User> users = new List<User>();
                users = userProcess.GetAll();
                return View(users);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

        [HttpPost]
        public ActionResult DeleteUser()
        {
            var userProvider = new RoleSecurityProvider();
            int userId = (int)(HttpContext.Session["userId"]);
            int userIdToDelete = Convert.ToInt32(Request.Form["userIddd"]);
            if (userProvider.IsUserAdmin(userId))
            {
                userProcess.Delete(userIdToDelete); 
                return RedirectToAction("UsersPanel");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Error");
            }
        }

    }
}