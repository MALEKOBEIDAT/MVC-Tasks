using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7._2._2023task.Controllers
{


    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            var c = db.Categories.ToList();
            return View(c);
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