using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogWeb.Entity;

namespace TravelBlogWeb.Controllers
{
    public class PartialController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }
        
    }
}