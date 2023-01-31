using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task1.Controllers
{
    public class MalekObeidatController : Controller
    {
        // GET: MalekObeidat
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Name()
        {
            return Content("<h1> Name:  Malek </h1");
        }

        public ActionResult Details()
        {
            return Content("<p> Full stack Developer </p>");
        }

        public ActionResult photo()
        {
            return Content("<img src='images/profile.jpg'/>");
        }

        public ActionResult link()
        {
            return Content("<a href='https://www.linkedin.com/in/malek-obeidat-a52281253/'>Linkedin</a>");
        }
    }
}