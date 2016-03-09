using jamboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jamboard.Controllers
{
    public class SkaterController : Controller
    {
        // GET: Skater
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            return View(db.Skaters);
        }

        // GET: Skater/Details/5
        public ActionResult Details()
        {
            var sk8r = new Models.Skater { Id = 5, Name = "Hostile Beehavior", Number = "1B" };
            return View(sk8r);
        }

        // GET: Skater/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skater/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var db = new ApplicationDbContext();
                db.Skaters.Add(new Models.Skater { Id = 5, Name = "Hostile Beehavior", Number = "1B" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skater/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skater/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skater/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Skater/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
