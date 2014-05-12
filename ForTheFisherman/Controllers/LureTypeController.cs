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
    public class LureTypeController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /LureType/

        public ActionResult Index()
        {
            return View(db.LureType.ToList());
        }

        //
        // GET: /LureType/Details/5

        public ActionResult Details(int id = 0)
        {
            LureType luretype = db.LureType.Find(id);
            if (luretype == null)
            {
                return HttpNotFound();
            }
            return PartialView(luretype);
        }

        //
        // GET: /LureType/Create


        public ActionResult Create()
        {

            //Create empty luretype and store the next available id for luretypes in its id
            LureType lureType = new LureType();
            var lastLureType = db.LureType.OrderByDescending(lt => lt.ltId).FirstOrDefault();
            lureType.ltId = (lastLureType.ltId) + 1;
            return PartialView(lureType);
        }

        //
        // POST: /LureType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LureType lureType)
        {
            if (ModelState.IsValid)
            {
                db.LureType.Add(lureType);
                db.SaveChanges();
                return RedirectToAction("CreateSuccess", lureType);
            }

            return PartialView(lureType);
        }

        //
        // GET: /LureType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LureType luretype = db.LureType.Find(id);
            if (luretype == null)
            {
                return HttpNotFound();
            }
            return PartialView(luretype);
        }

        //
        // POST: /LureType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LureType luretype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luretype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(luretype);
        }

        //
        // GET: /LureType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LureType luretype = db.LureType.Find(id);
            if (luretype == null)
            {
                return HttpNotFound();
            }
            return View(luretype);
        }

        //
        // POST: /LureType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                LureType luretype = db.LureType.Find(id);
                db.LureType.Remove(luretype);
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

        // GET: /Lure/CreateSuccess

        public ActionResult CreateSuccess(LureType lureType)
        {
            TempData["ltId"] = lureType.ltId;
            return PartialView();
        }
       
        
        // GET: /Luretypes/List

        /// <summary>
        /// Returns an updated list of luretypes to populate the dropdown list
        /// </summary>
        /// <returns></returns>

        public ActionResult List()
        {
            List<SelectListItem> lureTypes = new List<SelectListItem>();
            lureTypes.Add(new SelectListItem { Text = "", Value = "" });

            foreach (LureType lureType in db.LureType)
            {
                lureTypes.Add(new SelectListItem { Text = lureType.typename, Value = lureType.ltId.ToString() });
            }

            return Json(lureTypes, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}