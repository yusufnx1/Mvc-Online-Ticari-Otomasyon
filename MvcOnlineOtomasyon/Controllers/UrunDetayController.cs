using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            cs.Deger1 = c.Uruns.Where(x => x.UrunId == 1).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayId == 1).ToList();
            //var degerler = c.Uruns.Where(x => x.UrunId == 1);
            return View(cs);
        }
    }
}