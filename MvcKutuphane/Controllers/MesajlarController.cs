using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();

        // Gelen Kutusu
        public ActionResult Index()
        {
            if (Session["Mail"] == null)
            {
                return RedirectToAction("Login", "Giris"); // Giriş sayfasına yönlendir
            }

            string uyemail = Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR
                             .Where(x => x.ALICI == uyemail)
                             .ToList();
            return View(mesajlar);
        }

        // Giden Kutusu
        public ActionResult Giden()
        {
            if (Session["Mail"] == null)
            {
                return RedirectToAction("Login", "Giris"); // Giriş sayfasına yönlendir
            }

            string uyemail = Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR
                             .Where(x => x.GONDEREN == uyemail)
                             .ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN = uyemail.ToString();
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }

       
    }
}