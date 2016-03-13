using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jamboard.Models;

namespace jamboard.Controllers
{
    public class SkatersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Skaters
        public ActionResult Index()
        {
            return View(db.Skaters.ToList());
        }

        // GET: Skaters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skater skater = db.Skaters.Find(id);
            if (skater == null)
            {
                return HttpNotFound();
            }
            return View(skater);
        }

        // GET: Skaters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skaters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Number,TeamId")] Skater skater)
        {
            if (ModelState.IsValid)
            {
                db.Skaters.Add(skater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skater);
        }

        // GET: Skaters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skater skater = db.Skaters.Find(id);
            if (skater == null)
            {
                return HttpNotFound();
            }
            return View(skater);
        }

        // POST: Skaters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Number,TeamId")] Skater skater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skater);
        }

        // GET: Skaters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skater skater = db.Skaters.Find(id);
            if (skater == null)
            {
                return HttpNotFound();
            }
            return View(skater);
        }

        // POST: Skaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skater skater = db.Skaters.Find(id);
            db.Skaters.Remove(skater);
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
