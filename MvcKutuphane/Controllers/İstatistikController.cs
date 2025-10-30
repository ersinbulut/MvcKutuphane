using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        DBKUTUPHANEEntities1 db=new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKİTAP.Count();
            var deger3=db.TBLKİTAP.Where(x=>x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
           
            return View();
        }

        public ActionResult Hava() 
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri() 
        {
            return View();
        }
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength >0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            // 1. Kitap sayısı
            var deger1 = db.TBLKİTAP.Count();

            // 2. Üye sayısı
            var deger2 = db.TBLUYELER.Count();

            // 3. Kasadaki toplam para
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);

            // 4. Ödünçteki kitap sayısı
            var deger4 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();

            // 5. Kategori sayısı
            var deger5 = db.TBLKATEGORİ.Count();

            // 6. En aktif üye
            var deger6 = db.TBLHAREKET
                .GroupBy(x => x.UYE)
                .OrderByDescending(z => z.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var aktifUye = db.TBLUYELER.Where(x => x.ID == deger6)
                .Select(y => y.AD + " " + y.SOYAD)
                .FirstOrDefault();

            // 7. En çok okunan kitap
            var deger7 = db.TBLHAREKET
                .GroupBy(x => x.KITAP)
                .OrderByDescending(z => z.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var cokOkunanKitap = db.TBLKİTAP.Where(x => x.ID == deger7)
                .Select(y => y.AD)
                .FirstOrDefault();

            // 8. En fazla kitabı olan yazar (stored procedure)
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();

            // 9. En iyi yayınevi
            var deger9 = db.TBLKİTAP
                .GroupBy(x => x.YAYINEVİ)
                .OrderByDescending(z => z.Count())
                .Select(y => y.Key)
                .FirstOrDefault();

            // 10. En başarılı personel (örnek)
            var deger10 = db.TBLHAREKET
                .GroupBy(x => x.PERSONEL)
                .OrderByDescending(z => z.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var basariliPersonel = db.TBLPERSONEL
                .Where(x => x.ID == deger10)
                .Select(y => y.PERSONEL)
                .FirstOrDefault();

            // 11. Toplam mesaj sayısı
            var deger11 = db.TBLILETISIM.Count();

            // 12. Bugünkü emanet sayısı
            DateTime bugun = DateTime.Today;
            var deger12 = db.TBLHAREKET
                .Where(x => x.ALISTARİH == bugun)
                .Count();

            // ViewBag’lere aktarım
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = aktifUye ?? "Bulunamadı";
            ViewBag.dgr7 = cokOkunanKitap ?? "Bulunamadı";
            ViewBag.dgr8 = deger8 ?? "Bulunamadı";
            ViewBag.dgr9 = deger9 ?? "Bulunamadı";
            ViewBag.dgr10 = basariliPersonel ?? "Bulunamadı";
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;

            return View();
        }


    }
}