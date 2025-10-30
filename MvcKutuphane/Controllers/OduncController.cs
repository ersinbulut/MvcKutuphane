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
            var values = db.TBLHAREKET.Where(x=>x.ISLEMDURUM == false).ToList();
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

        public ActionResult Odunciade(TBLHAREKET p)
        {
            var odn = db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odn);
        }
        [HttpPost]
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var odn = db.TBLHAREKET.Find(p.ID);
            odn.UYEGETIRTARIH = p.UYEGETIRTARIH;
            odn.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}