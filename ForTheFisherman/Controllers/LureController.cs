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
    public class LureController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /Lure/
        [Authorize]
        public ActionResult Index()
        {
            var lure = db.Lure.Include(l => l.LureType);
            return View(lure.ToList());
        }

       
        /*// GET: /Lure/Details/5

        public ActionResult Details(int id = 0)
        {
            Lure lure = db.Lure.Find(id);
            if (lure == null)
            {
                return HttpNotFound();
            }
            return View(lure);
        }*/

        //
        // GET: /Lure/Create

        public ActionResult Create()
        {
            //Create empty lure and store the next available id for lures in its id
            ViewBag.ltId = new SelectList(db.LureType, "ltId", "typename");
            Lure lure = new Lure();
            var lastLure = db.Lure.OrderByDescending(lt => lt.lId).FirstOrDefault();
            lure.lId = (lastLure.lId) + 1;
            return View(lure);
        }

        //
        // POST: /Lure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lure lure, bool returnToHomePage = false)
        {
            if (ModelState.IsValid)
            {
                db.Lure.Add(lure);
                db.SaveChanges();
    
                if (returnToHomePage == true) //if the request came from the homepage the user gets redirected to it, else the list of lures is shown
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ltId = new SelectList(db.LureType, "ltId", "typename", lure.ltId);
            return View(lure);
        }

        //
        // GET: /Lure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lure lure = db.Lure.Find(id);
            if (lure == null)
            {
                return HttpNotFound();
            }
            ViewBag.ltId = new SelectList(db.LureType, "ltId", "typename", lure.ltId);
            return View(lure);
        }

        //
        // POST: /Lure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lure lure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ltId = new SelectList(db.LureType, "ltId", "typename", lure.ltId);
            return View(lure);
        }

        //
        // GET: /Lure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Lure lure = db.Lure.Find(id);
            if (lure == null)
            {
                return HttpNotFound();
            }
            return View(lure);
        }

        //
        // POST: /Lure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            Lure lure = db.Lure.Find(id);
            try
            {
                db.Lure.Remove(lure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /// if the delete cannot be done an error message is created and the user is redirected to the lure index page where the error is displayed.
            catch {
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