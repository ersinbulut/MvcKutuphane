using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }

        public List<Class1> liste()
        {
            List<Class1> grafik = new List<Class1>();
            grafik.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayi = 7
            });
            grafik.Add(new Class1()
            {
                yayinevi = "Mars",
                sayi = 4
            });
            grafik.Add(new Class1()
            {
                yayinevi = "Jupiter",
                sayi = 6
            });
            return grafik;
        }
    }
}