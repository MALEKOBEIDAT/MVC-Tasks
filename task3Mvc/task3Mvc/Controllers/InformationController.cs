using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using task3Mvc;

namespace task3Mvc.Controllers
{
    public class InformationController : Controller
    {
        private Entities db = new Entities();

        // GET: Information
        public ActionResult Index(string FirstName,string name)
        {


            var emp = db.Information.ToList();


            if (name == "First") { emp = db.Information.Where(x => x.FirstName.Contains(FirstName)).ToList(); }

           else if (name == "Last") { emp = db.Information.Where(x => x.LastName.Contains(FirstName)).ToList(); }

            else if (name == "Email") { emp = db.Information.Where(x => x.Email.Contains(FirstName)).ToList(); }
            else if (name == "Phone") { emp = db.Information.Where(x => x.Phone.ToString().Contains(FirstName)).ToList(); }


            else if (name == "Age") { emp = db.Information.Where(x => x.Age.ToString().Contains(FirstName)).ToList(); }

            


            return View(emp);

            
            



        //    return View(db.Information.Where(x => x.FirstName.Contains(FirstName) || x.LastName.Contains(FirstName) || x.Email.Contains(FirstName) || FirstName == null).ToList());

        }



        

        // GET: Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // GET: Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Phone,Age,Job_Title,Gender,Image,Cv")] Information information, HttpPostedFileBase Image,HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (!Image.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(information);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    Image.SaveAs(path);
                    information.Image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(information);
                }

                if (cv != null)
                {
                    //if (!image2.ContentType.ToLower().StartsWith("image/"))
                    //{
                    //    ModelState.AddModelError("", "file uploaded is not an image");
                    //    return View(user);
                    //}
                    string folderPath = Server.MapPath("~/Content/CVs");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(cv.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    cv.SaveAs(path);
                    information.Cv = "../Content/CVs/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an cv.");
                    return View(information);
                }

                db.Information.Add(information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(information);
        }

        // GET: Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone,Age,Job_Title,Gender")] Information information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(information).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(information);
        }

        // GET: Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Information information = db.Information.Find(id);
            db.Information.Remove(information);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
