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
        // GET: /Catch/IndexPartial

        public ActionResult IndexPartial()
        {
            var fishcatch = db.Catch
                .Include(c => c.FishSpecies)
                .Include(c => c.Lure)
                .Include(c => c.FishingSession)
                .Where(f => f.FishingSession.Fisherman.eMail == User.Identity.Name);

            return PartialView(fishcatch.ToList());
        }

        //
        // GET: /Catch/ListCatch

        public ActionResult ListCatch()
        {
            var fishcatch = db.Catch
                .Include(c => c.FishSpecies)
                .Include(c => c.Lure)
                .Include(c => c.FishingSession)
                .Where(f => f.FishingSession.Fisherman.eMail == User.Identity.Name);
            return PartialView(fishcatch.ToList());
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

            return PartialView(fishcatch);
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
            return PartialView(fishcatch);
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
                return RedirectToAction("CreateSuccess");
            }

            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname", fishcatch.fiId);
            ViewBag.lId = new SelectList(db.Lure, "lId", "name", fishcatch.lId);
            ViewBag.fsId = new SelectList(db.FishingSession
            .Where(f => f.Fisherman.eMail == User.Identity.Name),
           "fsId", "description", fishcatch.fsId);

            return PartialView(fishcatch);
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
            ViewBag.fsId = new SelectList(db.FishingSession
            .Where(f => f.Fisherman.eMail == User.Identity.Name),
            "fsId", "description", fishcatch.fsId);
            return PartialView(fishcatch);
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
                return RedirectToAction("CreateSuccess");
            }
            ViewBag.fiId = new SelectList(db.FishSpecies, "fiId", "fishname", fishcatch.fiId);
            ViewBag.lId = new SelectList(db.Lure, "lId", "name", fishcatch.lId);
            ViewBag.fsId = new SelectList(db.FishingSession, "fsId", "description", fishcatch.fsId);
            return PartialView(fishcatch);
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

        //
        // GET: /Catch/DeleteAjax/5

        public ActionResult DeleteAjax(int id = 0, string view = "")
        {
            Catch fishcatch = db.Catch.Find(id);
            if (fishcatch == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.Catch.Remove(fishcatch);
                db.SaveChanges();
            }

            catch
            {
                TempData["deleteErrorMessage"] = "Cannot delete this item";
            }

            if (view == "ListCatch")
            {
                return RedirectToAction("ListCatch");
            }
            else
            {
                return RedirectToAction("IndexPartial");
            }
        }


        // GET: /Catch/CreateSuccess

        public ActionResult CreateSuccess(Catch fishcatch)
        {
            TempData["cId"] = fishcatch.cId;
            return PartialView();
        }


        // GET: /Catch/List

        /// <summary>
        /// Returns an updated list of fish species to populate the dropdown list
        /// </summary>
        /// <returns></returns>

        public ActionResult List()
        {
            List<SelectListItem> fishcatch = new List<SelectListItem>();
            fishcatch.Add(new SelectListItem { Text = "", Value = "" });

            foreach (Catch fishcatches in db.Catch)
            {
                fishcatch.Add(new SelectListItem { Text = fishcatches.description, Value = fishcatches.cId.ToString() });
            }

            return Json(fishcatch, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}