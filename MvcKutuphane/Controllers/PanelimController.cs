using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities1 db=new DBKUTUPHANEEntities1();
        // GET: Panelim
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye=db.TBLUYELER.FirstOrDefault(x=>x.MAIL ==kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;

            db.SaveChanges();
            return RedirectToAction("GirisYap", "Login");
        }

        public ActionResult Kitaplarim()
        {
            // Kullanıcı oturumu kontrolü
            if (Session["Mail"] == null)
            {
                return RedirectToAction("Login", "Giris"); // Giriş sayfasına yönlendir
            }

            string kullanici = Session["Mail"].ToString();

            // Üye ID'sini bul
            var id = db.TBLUYELER
                       .Where(x => x.MAIL == kullanici)
                       .Select(z => z.ID)
                       .FirstOrDefault();

            // Üyenin aldığı kitapları getir
            var degerler = db.TBLHAREKET
                             .Where(x => x.UYE == id)
                             .ToList();

            return View(degerler);
        }


        public ActionResult Duyurular()
        {
           var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}