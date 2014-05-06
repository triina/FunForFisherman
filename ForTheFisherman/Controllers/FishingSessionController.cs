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
    public class FishingSessionController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        //
        // GET: /FishingSession/
        [Authorize]
        public ActionResult Index()
        {
            var fishingsession = db.FishingSession
                .Include(f => f.Catch)
                .Include(f => f.Fisherman)
                .Include(f => f.FishingMethod)
                .Include(f => f.LocationMarking)
                .Where(f => f.Fisherman.eMail == User.Identity.Name);
            return View(fishingsession.ToList());
        }

        //
        // GET: /FishingSession/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    FishingSession fishingsession = db.FishingSession.Find(id);
        //    if (fishingsession == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fishingsession);
        //}

        //
        // GET: /FishingSession/Create

        public ActionResult Create()
        {
            //ViewBag.cId = new SelectList(db.Catch, "cId", "description");
            //ViewBag.fId = new SelectList(db.Fisherman, "fId", "firstName");
            //ViewBag.fmId = new SelectList(db.FishingMethod, "fmId", "methodname");
            //ViewBag.lmId = new SelectList(db.LocationMarking, "lmId", "sublocation");
            //return View();
             

            ViewBag.cId = new SelectList(db.Catch, "cId", "description");
            //ViewBag.fId = new SelectList(db.Fisherman, "fId", "firstName");
            ViewBag.fmId = new SelectList(db.FishingMethod, "fmId", "methodname");
            ViewBag.lmId = new SelectList(db.LocationMarking, "lmId", "sublocation");
            FishingSession session = new FishingSession();
            var lastSession = db.FishingSession
                .OrderByDescending(fs => fs.fsId)
                .FirstOrDefault();
            session.fsId = (lastSession.fsId) + 1;

            var currentFisherman = db.Fisherman.Where(f => f.eMail == User.Identity.Name).First();
            session.fId = currentFisherman.fId;

            return View(session);
        }

        //
        // POST: /FishingSession/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FishingSession fishingsession)
        {
            if (ModelState.IsValid)
            {
                db.FishingSession.Add(fishingsession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cId = new SelectList(db.Catch, "cId", "description", fishingsession.cId);
            //ViewBag.fId = new SelectList(db.Fisherman, "fId", "firstName", fishingsession.fId);
            ViewBag.fmId = new SelectList(db.FishingMethod, "fmId", "methodname", fishingsession.fmId);
            ViewBag.lmId = new SelectList(db.LocationMarking, "lmId", "sublocation", fishingsession.lmId);
            return View(fishingsession);
        }

        //
        // GET: /FishingSession/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FishingSession fishingsession = db.FishingSession.Find(id);
            if (fishingsession == null)
            {
                return HttpNotFound();
            }
            ViewBag.cId = new SelectList(db.Catch, "cId", "description", fishingsession.cId);
            //ViewBag.fId = new SelectList(db.Fisherman, "fId", "firstName", fishingsession.fId);
            ViewBag.fmId = new SelectList(db.FishingMethod, "fmId", "methodname", fishingsession.fmId);
            ViewBag.lmId = new SelectList(db.LocationMarking, "lmId", "sublocation", fishingsession.lmId);
            return View(fishingsession);
        }

        //
        // POST: /FishingSession/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FishingSession fishingsession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishingsession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cId = new SelectList(db.Catch, "cId", "description", fishingsession.cId);
            //ViewBag.fId = new SelectList(db.Fisherman, "fId", "firstName", fishingsession.fId);
            ViewBag.fmId = new SelectList(db.FishingMethod, "fmId", "methodname", fishingsession.fmId);
            ViewBag.lmId = new SelectList(db.LocationMarking, "lmId", "sublocation", fishingsession.lmId);
            return View(fishingsession);
        }

        //
        // GET: /FishingSession/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FishingSession fishingsession = db.FishingSession.Find(id);
            if (fishingsession == null)
            {
                return HttpNotFound();
            }
            return View(fishingsession);
        }

        //
        // POST: /FishingSession/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FishingSession fishingsession = db.FishingSession.Find(id);
            db.FishingSession.Remove(fishingsession);
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