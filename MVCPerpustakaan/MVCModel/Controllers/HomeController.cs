using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCModel.Models;

namespace MVCModel.Controllers
{
    public class HomeController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string text)
        {
            var results = db.Anggota
            .Where(a => a.NamaAnggota.Contains(text))
            .Take(10);
            return View(results);
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