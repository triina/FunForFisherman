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
        [Authorize]
        public ActionResult Index()
        {
            var fishcatch = db.Catch.Include(fi => fi.FishSpecies).Include(l => l.Lure);
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

            try
            {
                db.Catch.Remove(fishcatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

             /// if the delete cannot be done an error message is created and the user is redirected to the lure index page where the error is displayed.
            catch
            {
                TempData["deleteErrorMessage"] = "Cannot delete this item";

                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

