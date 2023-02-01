using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2New.Models;

namespace Task2New.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            Student s = new Student();
            List<object> Student = new List<object>()
            {
                new Student{ID=1,Name="Malek",Major="Computer Scince",Faculity="Information Tecnology and Computer Scince"},

                new Student{ID=2,Name="Mohammad",Major="Cyber Securty",Faculity="Information Tecnology and Computer Scince"},

                new Student{ID=3,Name="Ahmad",Major="Artifcal Intellgent",Faculity="Information Tecnology and Computer Scince"},

                new Student{ID=4,Name="Omar",Major="Bussines Information Tecnology",Faculity="Information Tecnology and Computer Scince"},


            };

            ViewBag.Student = Student;
            return View();
        }
    }
}