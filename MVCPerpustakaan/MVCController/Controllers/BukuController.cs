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

        //GET : /Buku/Browse?category=Fiksi
        public string Browse(string category)
        {
            string message =HttpUtility.HtmlEncode($"Ini Action Browse, Category = {category}");
            return message;

        }

        // GET: /Buku/Details/3
        public string Details(int id)
        {
            string message = HttpUtility.HtmlEncode($"Ini Action Details, ID = {id}");
            return message;

        }
    }
}