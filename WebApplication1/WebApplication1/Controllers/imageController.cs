using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace WebApplication1.Controllers
{
    public class imageController : Controller
    {
        // GET: image
        public string Index()
        {


            return ("<img src='image/juice.png'></img>");

        }

       
        


        
    }
}