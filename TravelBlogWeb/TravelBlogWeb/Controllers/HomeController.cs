using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogWeb.Entity;
using TravelBlogWeb.Entity.Data;
using TravelBlogWeb.Models;

namespace TravelBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        BlogCityRelationProcess blogCityRelationProcess = new BlogCityRelationProcess();
        BlogPostProcess blogPostProcess = new BlogPostProcess();
        public ActionResult Index()
        {
            ViewBag.popularsMain = blogPostProcess.GetTenPopulars().Take(7).ToList();
            ViewBag.popularsAside = blogPostProcess.GetTenPopulars().Take(5).ToList();
            ViewBag.latests = blogPostProcess.GetTenLatests().ToList();
            ViewBag.counter = 1;

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.state = true;
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            var cities = blogCityRelationProcess.GetAll();
            ViewBag.cities = cities;
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(BlogPost model)
        {


            string title = Request.Form["blogTitle"];
            string content = Request.Form["editor"];
            int selectedCityId = int.Parse(Request.Form["citiesList"]);


            BlogPost newBlogPost = new BlogPost
            {
                UserId = Convert.ToInt32(HttpContext.Session["userId"]),
                Title = title,
                Content = content,
                CreationDate = DateTime.Now,

            };

            blogPostProcess.Add(newBlogPost);

            CityBlogRelation cityBlogRelation = new CityBlogRelation
            {
                BlogPostId = newBlogPost.Id,
                CityId = selectedCityId,
            };

            blogCityRelationProcess.Add(cityBlogRelation);

            return RedirectToAction("Index");



        }
    }
}