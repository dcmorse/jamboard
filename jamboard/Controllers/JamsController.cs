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
    public class JamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jams
        public ActionResult Index()
        {
            var jams = db.Jams.Include(j => j.Team);
            return View(jams.ToList());
        }

        // GET: Jams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            return View(jam);
        }

        // GET: Jams/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Jams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamId,Timestamp")] Jam jam)
        {
            if (ModelState.IsValid)
            {
                db.Jams.Add(jam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", jam.TeamId);
            return View(jam);
        }

        // GET: Jams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", jam.TeamId);
            return View(jam);
        }

        // POST: Jams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamId,Timestamp")] Jam jam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", jam.TeamId);
            return View(jam);
        }

        // GET: Jams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            return View(jam);
        }

        // POST: Jams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jam jam = db.Jams.Find(id);
            db.Jams.Remove(jam);
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
