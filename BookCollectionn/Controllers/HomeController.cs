using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCollection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Us";
            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }
    }
}