using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserBaseWebApplication;
using UserBaseWebApplication.Models;

namespace UserBaseWebApplication.Controllers
{
    public class CourseTsController : Controller
    {
        private UsersBaseAppEntities db = new UsersBaseAppEntities();

        // GET: CourseTs
        public ActionResult Index()
        {
            return View(db.CourseTs.ToList());
        }

        // GET: CourseTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // GET: CourseTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,course,duration")] CourseT courseT)
        {
            if (ModelState.IsValid)
            {
                db.CourseTs.Add(courseT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseT);
        }

        // GET: CourseTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // POST: CourseTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,course,duration")] CourseT courseT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseT);
        }

        // GET: CourseTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseT courseT = db.CourseTs.Find(id);
            if (courseT == null)
            {
                return HttpNotFound();
            }
            return View(courseT);
        }

        // POST: CourseTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseT courseT = db.CourseTs.Find(id);
            db.CourseTs.Remove(courseT);
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
