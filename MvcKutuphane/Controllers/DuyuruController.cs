using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        // GET: Duyuru
        public ActionResult Index()
        {
            var values = db.TBLDUYURULAR.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURULAR p)
        {
            db.TBLDUYURULAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DuyuruGuncelle(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            return View("DuyuruGuncelle", duyuru);
        }
        [HttpPost]
        public ActionResult DuyuruGuncelle(TBLDUYURULAR p)
        {
            var duyuru = db.TBLDUYURULAR.Find(p.ID);
            duyuru.KATEGORİ = p.KATEGORİ;
            duyuru.ICERİK = p.ICERİK;
            duyuru.TARİH = p.TARİH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}