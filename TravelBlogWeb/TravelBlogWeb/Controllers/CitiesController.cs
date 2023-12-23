using System;
using System.Web.Mvc;
using TravelBlogWeb.Controllers;
using TravelBlogWeb.Entity;
using TravelBlogWeb.Models;

public class CitiesController : Controller
{
    BlogCityRelationProcess blogCityRelationProcess = new BlogCityRelationProcess();
    BlogPostProcess blogPostProcess = new BlogPostProcess();
    PartialProcess partialProcess=new PartialProcess();



    public ActionResult Index()
    {
        var allCities = blogCityRelationProcess.GetAll();
        return View(allCities);
    }


    // İlgili şehire ait blogların gösterilecek action
    public ActionResult CityBlogs(int cityId)
    {
        if (cityId == 0)
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
        var blogCity = blogCityRelationProcess.GetCityBlogs(cityId);

        if (blogCity == null)
        {
            return HttpNotFound();
        }

        var singleCityBlogs = blogPostProcess.GetCityBlogPosts(blogCity);

        var populars = partialProcess.GetPopulars();
        var latests = partialProcess.GetLatests();
        ViewBag.populars = populars;
        ViewBag.latests = latests;

        return View(singleCityBlogs);

    }
    public ActionResult ShowBlog(int id)
    {

        
        return RedirectToAction("ShowBlog", "SingleBlog", new { id = id });
    }


}
