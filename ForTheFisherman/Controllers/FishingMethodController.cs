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
    public class FishingMethodController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /FishingMethod/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.FishingMethod.ToList());
        }

        //
        // GET: /FishingMethod/Details/5

        public ActionResult Details(int id = 0)
        {
            FishingMethod fishingmethod = db.FishingMethod.Find(id);
            if (fishingmethod == null)
            {
                return HttpNotFound();
            }
            return View(fishingmethod);
        }

        //
        // GET: /FishingMethod/Create

        public ActionResult Create()
        {
            FishingMethod fishingMethod = new FishingMethod();
            var lastFishingMethod = db.FishingMethod.OrderByDescending(fm => fm.fmId).FirstOrDefault();
            fishingMethod.fmId = (lastFishingMethod.fmId) + 1;
            return View(fishingMethod);
        }

        //
        // POST: /FishingMethod/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FishingMethod fishingmethod)
        {
            if (ModelState.IsValid)
            {
                db.FishingMethod.Add(fishingmethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fishingmethod);
        }

        //
        // GET: /FishingMethod/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FishingMethod fishingmethod = db.FishingMethod.Find(id);
            if (fishingmethod == null)
            {
                return HttpNotFound();
            }
            return View(fishingmethod);
        }

        //
        // POST: /FishingMethod/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FishingMethod fishingmethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishingmethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fishingmethod);
        }

        //
        // GET: /FishingMethod/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FishingMethod fishingmethod = db.FishingMethod.Find(id);
            if (fishingmethod == null)
            {
                return HttpNotFound();
            }
            return View(fishingmethod);
        }

        //
        // POST: /FishingMethod/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                FishingMethod fishingmethod = db.FishingMethod.Find(id);
                db.FishingMethod.Remove(fishingmethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["deleteErrorMessage"] = "This item cannot be deleted.";
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