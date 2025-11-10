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
            List<SelectListItem> deger1 = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.TBLKİTAP.Where(y => y.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();

            ViewBag.Uyeler = deger1;
            ViewBag.Kitaplar = deger2;
            ViewBag.Personel = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYELER.FirstOrDefault(x => x.ID == p.UYE);
            var d2 = db.TBLKİTAP.FirstOrDefault(x => x.ID == p.KITAP);
            var d3 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == p.PERSONEL);

            p.TBLUYELER = d1;
            p.TBLKİTAP = d2;
            p.TBLPERSONEL = d3;

            db.TBLHAREKET.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
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