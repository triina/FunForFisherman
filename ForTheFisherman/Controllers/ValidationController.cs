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
    public class ValidationController : Controller
    {
        private FishermanDBEntities1 db = new FishermanDBEntities1();

        // GET: /Validation/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Check for unique email
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public JsonResult CheckEmail(string email, int fId = 0)
        {
            //var result = db.Fisherman.SqlQuery("SELECT * FROM Fisherman WHERE eMail='" + email + "' AND fId <> " + fId).Count() == 0;
            var result = false;
            if (fId != 0)
            {
                result = db.Fisherman.SingleOrDefault(f => f.eMail == email && f.fId != fId) == null;
            }
            else
            {
                result = db.Fisherman.SingleOrDefault(f => f.eMail == email) == null;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLureTypeName(string typename, int ltId)
        {
            var result = db.LureType.SingleOrDefault(lt => lt.typename == typename && lt.ltId != ltId) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLureName(string name, int lId)
        {
            var result = db.Lure.SingleOrDefault(l => l.name == name && l.lId != lId) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckFishName(string fishname, int fiId)
        {
            var result = db.FishSpecies.SingleOrDefault(fi => fi.fishname == fishname && fi.fiId != fiId) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckMethodName(string methodname, int fmId)
        {
            var result = db.FishingMethod.SingleOrDefault(m => m.methodname == methodname && m.fmId != fmId) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
