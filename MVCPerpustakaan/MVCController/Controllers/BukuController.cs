using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCController.Controllers
{
    public class BukuController : Controller
    {
        // GET: Buku
        public string Index()
        {
            return "Ini Action Index";
        }

        public string Browse()
        {
            return "Ini Action Browse";
        }

        public string Details()
        {
            return "Ini Action Details";
        }
    }
}