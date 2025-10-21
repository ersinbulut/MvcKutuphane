using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;

            // Kullanıcı arama kutusuna değer girmişse filtre uygula
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(k => k.AD.Contains(p));
            }

            return View(kitaplar.ToList());
        }


        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP p)
        {
            var ktg = db.TBLKATEGORİ.FirstOrDefault(m => m.ID == p.KATEGORİ);
            var yzr = db.TBLYAZAR.FirstOrDefault(m => m.ID == p.YAZAR);

            p.TBLKATEGORİ = ktg;
            p.TBLYAZAR = yzr;
            p.DURUM = true;
            db.TBLKİTAP.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KitapGuncelle(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGuncelle", kitap);
        }
        [HttpPost]
        public ActionResult KitapGuncelle(TBLKİTAP p)
        {
            var kitap = db.TBLKİTAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVİ = p.YAYINEVİ;
            var ktg = db.TBLKATEGORİ.FirstOrDefault(m => m.ID == p.KATEGORİ);
            var yzr = db.TBLYAZAR.FirstOrDefault(m => m.ID == p.YAZAR);
            kitap.KATEGORİ = ktg.ID;
            kitap.YAZAR = yzr.ID;
            kitap.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", kitap);
        }

    }
}