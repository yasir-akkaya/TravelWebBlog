using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogWeb.Entity;

namespace TravelBlogWeb.Controllers
{
    [Authorize]
    public class PanelPartialController : Controller
    {
        UserProcess userProccess = new UserProcess();
        
        public ActionResult AcountSideLeftBar()
        {
            var user = userProccess.Get((int)(HttpContext.Session["userId"]));
            return PartialView(user);
        }

       
    }
}