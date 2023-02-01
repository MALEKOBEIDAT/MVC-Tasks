using Mvc_task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_task2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {


            Student Details = new Student();


            List<object> Student = new List<object>()
            {

                new Student{ID=1,Name="Malek",Major="Comuter Scince",Faculity="Information Tecnology and Computer Scince"},

                new Student{ID=2,Name="Mohammad",Major="Econmic",Faculity="Econmy"},

              





        };
            ViewBag.Student=Student ;
            return View();

        }
    }
}