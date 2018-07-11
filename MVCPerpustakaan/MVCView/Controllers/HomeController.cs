using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return View("Contact");
            return View("~/Views/Example/Index.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ini adalah page about pada latihan View.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddNewView()
        {
            ViewBag.Message = "Contoh Add View";

            return View();
        }
    }
}