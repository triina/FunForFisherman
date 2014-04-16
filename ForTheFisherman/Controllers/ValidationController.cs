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
        public JsonResult CheckEmail(string email, string fId)
        {
            var result = db.Fisherman.SqlQuery("SELECT * FROM Fisherman WHERE eMail='" + email + "' AND fId <> '" + fId + "'").Count() == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLureTypeName(string typename, string ltId)
        {
            var result = db.LureType.SqlQuery("SELECT * FROM LureType WHERE typename='" + typename + "' AND ltId <> '" + ltId + "'").Count() == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLureName(string name, string lId)
        {
            var result = db.Lure.SqlQuery("SELECT * FROM Lure WHERE name='" + name + "' AND lId <> '" + lId + "'").Count() == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
