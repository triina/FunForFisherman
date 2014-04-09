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
            return View(luretype);
        }

        //
        // GET: /LureType/Create


        public ActionResult Create()
        {
        
            //Create empty lure and store the next available id for lure id
            LureType luretype = new LureType();
            var lureType=db.LureType.OrderByDescending(lt => lt.ltId).FirstOrDefault();
            luretype.ltId = (lureType.ltId)+1;
            return View(luretype);
        }

        //
        // POST: /LureType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LureType luretype)
        {
            if (ModelState.IsValid)
            {
                db.LureType.Add(luretype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(luretype);
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
            return View(luretype);
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
            return View(luretype);
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
            LureType luretype = db.LureType.Find(id);
            db.LureType.Remove(luretype);
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