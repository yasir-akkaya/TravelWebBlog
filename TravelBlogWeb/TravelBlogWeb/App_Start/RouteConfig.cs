using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelBlogWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //        routes.MapRoute(
            //    name: "CityBlogs",
            //    url: "Cities/{action}/{id}",
            //    defaults: new { controller = "Cities", action = "Index", id = UrlParameter.Optional }
            //);
        //    routes.MapRoute(
        //    name: "SingleBlog",
        //    url: "SingleBlog/{id}",
        //    defaults: new { controller = "SingleBlog", action = "Index", id = UrlParameter.Optional }
        //);

        }

    }
}
