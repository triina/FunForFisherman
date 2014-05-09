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
    public class WaterController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /Water/

        public ActionResult Index()
        {
            return View(db.Water.ToList());
        }

        //
        // GET: /Water/Details/5

        public ActionResult Details(int id = 0)
        {
            Water water = db.Water.Find(id);
            if (water == null)
            {
                return HttpNotFound();
            }
            return PartialView(water);
        }

        //
        // GET: /Water/Create

        public ActionResult Create()
        {
            //Create empty water and store the next available id for waters in its id
            Water water = new Water();
            var lastWater = db.Water.OrderByDescending(w => w.wId).FirstOrDefault();
            water.wId = (lastWater.wId) + 1;
            return PartialView(water);
        }

        //
        // POST: /Water/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Water water)
        {
            if (ModelState.IsValid)
            {
                db.Water.Add(water);
                db.SaveChanges();
                return RedirectToAction("CreateSuccess", water);
            }

            return PartialView(water);
        }

        //
        // GET: /Water/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Water water = db.Water.Find(id);
            if (water == null)
            {
                return HttpNotFound();
            }
            return PartialView(water);
        }

        //
        // POST: /Water/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Water water)
        {
            if (ModelState.IsValid)
            {
                db.Entry(water).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(water);
        }

        //
        // GET: /Water/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Water water = db.Water.Find(id);
            if (water == null)
            {
                return HttpNotFound();
            }
            return View(water);
        }

        //
        // POST: /Water/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try{
            Water water = db.Water.Find(id);
            db.Water.Remove(water);
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

        //
        // GET: /Water/CreateSuccess

        public ActionResult CreateSuccess(Water water)
        {
            TempData["wId"] = water.wId;
            return PartialView();
        }

        //
        // GET: /Water/List

        /// <summary>
        /// Returns an updated list of waters to populate the dropdown list
        /// </summary>
        /// <returns></returns>

        public ActionResult List()
        {
            List<SelectListItem> waters = new List<SelectListItem>();
            waters.Add(new SelectListItem { Text = "", Value = "" });

            foreach (Water water in db.Water)
            {
                waters.Add(new SelectListItem { Text = water.name, Value = water.wId.ToString() });
            }

            return Json(waters, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}