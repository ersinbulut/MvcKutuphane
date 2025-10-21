using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        // GET: Islem
        public ActionResult Index()
        {
            var values = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(values);
        }
    }
}