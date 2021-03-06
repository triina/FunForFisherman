﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForTheFisherman.Models;

namespace ForTheFisherman.Controllers
{
    public class GeoCoordinatesController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /GeoCoordinates/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.GeoCoordinates.ToList());
        }

        //
        // GET: /GeoCoordinates/Details/5

        public ActionResult Details(int id = 0)
        {
            GeoCoordinates geocoordinates = db.GeoCoordinates.Find(id);
            if (geocoordinates == null)
            {
                return HttpNotFound();
            }
            return PartialView(geocoordinates);
        }

        //
        // GET: /GeoCoordinates/Create

        public ActionResult Create()
        {
            // Create new coordinates and store the next available id for coordinates id
            GeoCoordinates geocoordinates = new GeoCoordinates();
            var geocoordinatesT = db.GeoCoordinates.OrderByDescending(f => f.gcId).FirstOrDefault();
            geocoordinates.gcId = geocoordinatesT.gcId + 1;
            return PartialView(geocoordinates);
        }

        //
        // POST: /GeoCoordinates/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeoCoordinates geocoordinates)
        {
            if (ModelState.IsValid)
            {
                db.GeoCoordinates.Add(geocoordinates);
                db.SaveChanges();
                //return RedirectToAction("Index");
                TempData["geocoordinates"] = geocoordinates;
                return RedirectToAction("CreateSuccess");
            }
            return PartialView(geocoordinates);
        }

        //
        // GET: /GeoCoordinates/CreateSuccess

        /// <summary>
        /// Provides the options to manually edit or update the coordinates after successful creation
        /// </summary>
        /// <returns></returns>

        public ActionResult CreateSuccess()
        {
            if (TempData["geocoordinates"] != null)
            {
                var geocoordinates = TempData["geocoordinates"];
                return PartialView(geocoordinates);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        //
        // GET: /GeoCoordinates/Update/5

        /// <summary>
        /// Updates the coordinates for a given id by recreating them automatically
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Update(int id = 0)
        {
            GeoCoordinates geocoordinates = db.GeoCoordinates.Find(id);
            if (geocoordinates == null)
            {
                return HttpNotFound();
            }
            return PartialView(geocoordinates);
        }

        //
        // POST: /GeoCoordinates/Update/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GeoCoordinates geocoordinates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geocoordinates).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                TempData["geocoordinates"] = geocoordinates;
                return RedirectToAction("CreateSuccess");
            }
            return PartialView(geocoordinates);
        }

        //
        // GET: /GeoCoordinates/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GeoCoordinates geocoordinates = db.GeoCoordinates.Find(id);
            if (geocoordinates == null)
            {
                return HttpNotFound();
            }
            return PartialView(geocoordinates);
        }

        //
        // POST: /GeoCoordinates/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeoCoordinates geocoordinates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geocoordinates).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                TempData["geocoordinates"] = geocoordinates;
                return RedirectToAction("CreateSuccess");
            }
            return PartialView(geocoordinates);
        }

        //
        // GET: /GeoCoordinates/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GeoCoordinates geocoordinates = db.GeoCoordinates.Find(id);
            if (geocoordinates == null)
            {
                return HttpNotFound();
            }
            return View(geocoordinates);
        }

        //
        // POST: /GeoCoordinates/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GeoCoordinates geocoordinates = db.GeoCoordinates.Find(id);
                db.GeoCoordinates.Remove(geocoordinates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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