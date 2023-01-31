using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public string Index()
        {
            return ("<a download='juice.png' href='../images/juice.png'> <img src='../images/juice.png'></a>");    
        }

        public ActionResult About()

        {
            return Content("Hello");

        }

        public ActionResult Contact()
        {
            return Content("Welcome");

        }


      


    }
}