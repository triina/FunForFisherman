using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForTheFisherman.Models;

namespace ForTheFisherman.Controllers
{
    public class CatchController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /Catch/

        public ActionResult Index()
        {
            var fishcatch = db.Catch
                .Include(c => c.FishSpecies)
                .Include(c => c.Lure)
                .Include(c => c.FishingSession)
                .Where(f => f.FishingSession.Fisherman.eMail == User.Identity.Name);
            return View(fishcatch.ToList());
        }

        //
        // GET: /Catch/Details/5

        public ActionResult Details(int id = 0)
        {
            Catch fishcatch = db.Catch.Find(id);
            if (fishcatch == null)
            {
                return HttpNotFound();
            }
            return View(fishcatch);
        }

        //
        // GET: /Catch/Create

        public ActionResult Create()
        {
            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname");
            ViewBag.lId = new SelectList(db.Lure, "lId", "name");
            ViewBag.fsId = new SelectList(db.FishingSession
                                        .Where(f => f.Fisherman.eMail == User.Identity.Name),
                                        "fsId", "description");
            Catch fishcatch = new Catch();
            var lastCatch = db.Catch.OrderByDescending(fi => fi.cId).OrderByDescending(fi => fi.cId).FirstOrDefault();
            fishcatch.cId = (lastCatch.cId) + 1;
            return View(fishcatch);
        }

        //
        // POST: /Catch/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catch fishcatch)
        {
            if (ModelState.IsValid)
            {
                db.Catch.Add(fishcatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname", fishcatch.fiId);
            ViewBag.lId = new SelectList(db.Lure, "lId", "name", fishcatch.lId);
            ViewBag.fsId = new SelectList(db.FishingSession
                                        .Where(f => f.Fisherman.eMail == User.Identity.Name),
                                        "fsId", "description", fishcatch.fsId);
            return View(fishcatch);
        }

        //
        // GET: /Catch/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Catch fishcatch = db.Catch.Find(id);
            if (fishcatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname", fishcatch.fiId);
            ViewBag.lId = new SelectList(db.Lure, "lId", "name", fishcatch.lId);
            ViewBag.fsId = new SelectList(db.FishingSession, "fsId", "description", fishcatch.fsId);
            return View(fishcatch);
        }

        //
        // POST: /Catch/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catch fishcatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishcatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname", fishcatch.fiId);
            ViewBag.lId = new SelectList(db.Lure, "lId", "name", fishcatch.lId);
            ViewBag.fsId = new SelectList(db.FishingSession, "fsId", "description", fishcatch.fsId);
            return View(fishcatch);
        }

        //
        // GET: /Catch/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Catch fishcatch = db.Catch.Find(id);
            if (fishcatch == null)
            {
                return HttpNotFound();
            }
            return View(fishcatch);
        }

        //
        // POST: /Catch/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catch fishcatch = db.Catch.Find(id);
            db.Catch.Remove(fishcatch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}