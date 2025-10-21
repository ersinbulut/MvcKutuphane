using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        // GET: Odunc
        public ActionResult Index()
        {
            var values = db.TBLHAREKET.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult OduncAl()
        {
            return View();
        }

        public ActionResult Odunciade(int id)
        {
            var odn = db.TBLHAREKET.Find(id);
            return View("Odunciade", odn);
        }

    }
}