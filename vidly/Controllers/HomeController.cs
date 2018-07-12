using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace vidly.Controllers
{
    public class HomeController : Controller
    {
        // This will allow access to the controller
        [AllowAnonymous]
        // Sample of how to cache the view
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "genre")]
        // Sample of how NOT to cache the view 
        // [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
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
    }
}