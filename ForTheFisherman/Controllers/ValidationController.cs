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
    }
}
