using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
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
            var fishcatch = db.Catch.Include(c => c.FishSpecies);
            return View(fishcatch.ToList());
        }

        //
        // GET: /Catch/Details/5

        

        //
        // GET: /Catch/Create

        public ActionResult Create()
        {
           

            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname");
            Catch fishcatch = new Catch();
            var lastCatch = db.Catch.OrderByDescending(fs => fs.cId).FirstOrDefault();
            fishcatch.cId = (lastCatch.fiId) + 1;
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
            Catch fishspecies = db.Catch.Find(id);
            db.Catch.Remove(fishspecies);
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

