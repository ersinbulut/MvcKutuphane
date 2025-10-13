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
            var degerler = db.TBLKATEGORİ.ToList();
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
            db.TBLKATEGORİ.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}