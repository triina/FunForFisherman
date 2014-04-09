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
    public class FishermanController : Controller
    {
        private FishermanDBEntities db = new FishermanDBEntities();

        //fgkjfdlkgkjfdlögkfdgöldfg
        // GET: /Fisherman/

        public ActionResult Index()
        {
            return View(db.Fisherman.ToList());
        }

        //
        // GET: /Fisherman/Details/5

        public ActionResult Details(int id = 0)
        {
            Fisherman fisherman = db.Fisherman.Find(id);
            if (fisherman == null)
            {
                return HttpNotFound();
            }
            return View(fisherman);
        }

        //
        // GET: /Fisherman/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fisherman/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fisherman fisherman)
        {
            if (ModelState.IsValid)
            {
                db.Fisherman.Add(fisherman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fisherman);
        }

        //
        // GET: /Fisherman/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Fisherman fisherman = db.Fisherman.Find(id);
            if (fisherman == null)
            {
                return HttpNotFound();
            }
            return View(fisherman);
        }

        //
        // POST: /Fisherman/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fisherman fisherman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fisherman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fisherman);
        }

        //
        // GET: /Fisherman/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Fisherman fisherman = db.Fisherman.Find(id);
            if (fisherman == null)
            {
                return HttpNotFound();
            }
            return View(fisherman);
        }

        //
        // POST: /Fisherman/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fisherman fisherman = db.Fisherman.Find(id);
            db.Fisherman.Remove(fisherman);
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