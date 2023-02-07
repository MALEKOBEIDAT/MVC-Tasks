using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _7._2._2023task;

namespace _7._2._2023task.Controllers
{
    public class CategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatName,Image,Price,CatID,NewPrice")] Category category,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                if (Image != null)
                {
                    if (!Image.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(category);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    Image.SaveAs(path);
                    category.Image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(category);
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");


            }


            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatName,Image,Price,CatID,NewPrice")] Category category,HttpPostedFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (!Image.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(category);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    Image.SaveAs(path);
                    category.Image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(category);
                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
