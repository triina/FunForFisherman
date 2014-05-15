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
    public class LocationMarkingController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /LocationMarking/
        [Authorize]
        public ActionResult Index()
        {
            //var locationmarking = db.LocationMarking.Include(l => l.GeoCoordinates).Include(l => l.Water);
            //return View(locationmarking.ToList());
            return View();
        }

        //
        // GET: /LocationMarking/IndexPartial
        //[Authorize] // Is it needed here?
        public ActionResult IndexPartial()
        {
            var locationmarking = db.LocationMarking.Include(l => l.GeoCoordinates).Include(l => l.Water);
            return PartialView(locationmarking.ToList());
        }

        //
        // GET: /LocationMarking/Details/5

        public ActionResult Details(int id = 0)
        {
            LocationMarking locationmarking = db.LocationMarking.Find(id);
            if (locationmarking == null)
            {
                return HttpNotFound();
            }
            return View(locationmarking);
        }

        //
        // GET: /LocationMarking/Create

        public ActionResult Create()
        {
            ViewBag.gcId = new SelectList(db.GeoCoordinates, "gcId", "gcId");
            ViewBag.wId = new SelectList(db.Water, "wId", "name");

            LocationMarking locationMarking = new LocationMarking();
            var locationMarkingT = db.LocationMarking.OrderByDescending(l => l.lmId).FirstOrDefault();
            locationMarking.lmId = locationMarkingT.lmId + 1;
            return View(locationMarking);
        }

        //
        // POST: /LocationMarking/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationMarking locationmarking)
        {
            if (ModelState.IsValid)
            {
                db.LocationMarking.Add(locationmarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gcId = new SelectList(db.GeoCoordinates, "gcId", "gcId", locationmarking.gcId);
            ViewBag.wId = new SelectList(db.Water, "wId", "name", locationmarking.wId);
            return View(locationmarking);
        }

        //
        // GET: /LocationMarking/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LocationMarking locationmarking = db.LocationMarking.Find(id);
            if (locationmarking == null)
            {
                return HttpNotFound();
            }
            ViewBag.gcId = new SelectList(db.GeoCoordinates, "gcId", "gcId", locationmarking.gcId);
            ViewBag.wId = new SelectList(db.Water, "wId", "name", locationmarking.wId);
            return View(locationmarking);
        }

        //
        // POST: /LocationMarking/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationMarking locationmarking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationmarking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gcId = new SelectList(db.GeoCoordinates, "gcId", "gcId", locationmarking.gcId);
            ViewBag.wId = new SelectList(db.Water, "wId", "name", locationmarking.wId);
            return View(locationmarking);
        }

        //
        // GET: /LocationMarking/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LocationMarking locationmarking = db.LocationMarking.Find(id);
            if (locationmarking == null)
            {
                return HttpNotFound();
            }
            return View(locationmarking);
        }

        //
        // POST: /LocationMarking/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                LocationMarking locationmarking = db.LocationMarking.Find(id);
                db.LocationMarking.Remove(locationmarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch
            {
                TempData["deleteErrorMessage"] = "Cannot delete this item";
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /LocationMarking/DeleteAjax/5

        public ActionResult DeleteAjax(int id = 0)
        {
            LocationMarking locationmarking = db.LocationMarking.Find(id);
            if (locationmarking == null)
            {
                return HttpNotFound();
            }
            try
            {
                db.LocationMarking.Remove(locationmarking);
                db.SaveChanges();
                return RedirectToAction("IndexPartial");
            }

            catch
            {
                TempData["deleteErrorMessage"] = "Cannot delete this item";
                return RedirectToAction("IndexPartial");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}