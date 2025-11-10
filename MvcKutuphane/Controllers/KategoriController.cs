using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
       DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(x=>x.DURUM ==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİ p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            p.DURUM = true;
            db.TBLKATEGORİ.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
            kategori.DURUM = false;
            //db.TBLKATEGORİ.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            return View("KategoriGuncelle", ktg);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKATEGORİ p)
        {
            var ktg = db.TBLKATEGORİ.Find(p.ID);
            ktg.DURUM = true;
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}