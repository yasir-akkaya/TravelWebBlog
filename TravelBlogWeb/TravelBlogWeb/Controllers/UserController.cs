using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelBlogWeb.Entity;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Models;
using System.Net;
using System.Web.Helpers;


namespace TravelBlogWeb.Controllers
{
    public class UserController : Controller
    {
        UserProcess userProcess = new UserProcess();
        BlogPostProcess blogPostProcess = new BlogPostProcess();
        PartialProcess partialProcess = new PartialProcess();
        BlogCityRelationProcess blogCityRelationProcess = new BlogCityRelationProcess();
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(email, true);

                HttpContext.Session["userEmail"] = email;
                HttpContext.Session["name"] = user.Name;
                HttpContext.Session["img"] = user.Image;
                HttpContext.Session["userId"] = user.Id;



                if (user.IsAdmin == true)
                {
                    return RedirectToAction("Index", "Panel");

                }

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["Message"] = "Email or password is incorrect!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }




        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(User model)
        {
            try
            {
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                DateTime creationDate = DateTime.Now;


                User newUser = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    CreationDate = creationDate,
                    IsAdmin = false
                };

                userProcess.Add(newUser);


                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        public ActionResult MyBlogs()
        {
            List<BlogPost> myBlogs = new List<BlogPost>();
            int userId = Convert.ToInt32(HttpContext.Session["userId"]);
            myBlogs = blogPostProcess.GetMyBlogs(userId);
            var populars = partialProcess.GetPopulars();
            var latests = partialProcess.GetLatests();
            ViewBag.populars = populars;
            ViewBag.latests = latests;
            return View(myBlogs);
        }
        [HttpGet]
        public ActionResult EditMyBlog(int blogId)
        {

            var cities = blogCityRelationProcess.GetAll();
            ViewBag.cities = cities;

            var editedBlog = blogPostProcess.Get(blogId);
            


            return View(editedBlog);
        }
        [HttpPost]
        public ActionResult EditMyBlog(BlogPost model)
        {

            try
            {
                string title = Request.Form["blogTitle"];
                string content = Request.Form["editor"];
                int selectedCityId = int.Parse(Request.Form["citiesList"]);
                int editedBlogId = int.Parse(Request.Form["blogId"]);

                BlogPost editedBlogPost = new BlogPost
                {
                    Title = title,
                    Content = content,
                    UserId = Convert.ToInt32(HttpContext.Session["userId"])
                };

                blogPostProcess.Update(editedBlogPost, editedBlogId);

                var editedRelation = db.CityBlogRelations.FirstOrDefault(x => x.BlogPostId == editedBlogId);
                CityBlogRelation cityBlogRelation = new CityBlogRelation
                {
                    BlogPostId = editedBlogId,
                    CityId = selectedCityId,
                };
                blogCityRelationProcess.Update(cityBlogRelation, editedRelation.Id);
                

                ViewData["successMessage"] = "Your blog updated successfully!";

                return RedirectToAction("MyBlogs");
            }
            catch (Exception ex)
            {

                return View("Error");
            }




        }

    }
}