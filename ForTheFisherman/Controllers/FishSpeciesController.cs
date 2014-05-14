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
    public class FishSpeciesController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();
        //
        // GET: /FishSpecies/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.FishSpecies.ToList());
        }
        //
        // GET: /FishSpecies/Details/5

        public ActionResult Details(int id = 0)
        {
            FishSpecies fishspecies = db.FishSpecies.Find(id);
            if (fishspecies == null)
            {
                return HttpNotFound();
            }
            return PartialView(fishspecies);
        }

        //
        // GET: /FishSpecies/Create

        public ActionResult Create()
        {
            FishSpecies fishspecies = new FishSpecies();
            var lastFishSpecies = db.FishSpecies.OrderByDescending(fi => fi.fiId).FirstOrDefault();
            fishspecies.fiId = (lastFishSpecies.fiId) + 1;
            return PartialView(fishspecies);
        }

        //
        // POST: /FishSpecies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FishSpecies fishspecies)
        {
            if (ModelState.IsValid)
            {
                db.FishSpecies.Add(fishspecies);
                db.SaveChanges();
                return RedirectToAction("CreateSuccess", fishspecies);
            }

            return PartialView(fishspecies);
        }

        //
        // GET: /FishSpecies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FishSpecies fishspecies = db.FishSpecies.Find(id);
            if (fishspecies == null)
            {
                return HttpNotFound();
            }
            return PartialView(fishspecies);
        }

        //
        // POST: /FishSpecies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FishSpecies fishspecies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishspecies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(fishspecies);
        }

        //
        // GET: /FishSpecies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FishSpecies fishspecies = db.FishSpecies.Find(id);
            if (fishspecies == null)
            {
                return HttpNotFound();
            }
            return View(fishspecies);
        }

        //
        // POST: /FishSpecies/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                FishSpecies fishspecies = db.FishSpecies.Find(id);
                db.FishSpecies.Remove(fishspecies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["deleteErrorMessage"] = "Cannot delete this item";
                return RedirectToAction("Index");
            }
        }

        // GET: /Lure/CreateSuccess

        public ActionResult CreateSuccess(FishSpecies fishSpecies)
        {
            TempData["fiId"] = fishSpecies.fiId;
            return PartialView();
        }


        // GET: /FishSpecies/List

        /// <summary>
        /// Returns an updated list of fish species to populate the dropdown list
        /// </summary>
        /// <returns></returns>

        public ActionResult List()
        {
            List<SelectListItem> fishSpecieses = new List<SelectListItem>();
            fishSpecieses.Add(new SelectListItem { Text = "", Value = "" });

            foreach (FishSpecies fishSpecies in db.FishSpecies)
            {
                fishSpecieses.Add(new SelectListItem { Text = fishSpecies.fishname, Value = fishSpecies.fiId.ToString() });
            }

            return Json(fishSpecieses, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

