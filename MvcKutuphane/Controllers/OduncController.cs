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
            return View();
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
    }
}