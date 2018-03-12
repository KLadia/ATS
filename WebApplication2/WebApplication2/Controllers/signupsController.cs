using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class signupsController : Controller
    {
        private ATSdbEntities db = new ATSdbEntities();

        // GET: signups
        public ActionResult Index()
        {
            return View(db.signups.ToList());
        }

        // GET: signups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // GET: signups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: signups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "event_id,student_id,fname,lname,major,email")] signup signup)
        {
            if (ModelState.IsValid)
            {
                db.signups.Add(signup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signup);
        }

        // GET: signups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: signups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_id,student_id,fname,lname,major,email")] signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signup);
        }

        // GET: signups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signup signup = db.signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: signups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            signup signup = db.signups.Find(id);
            db.signups.Remove(signup);
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
