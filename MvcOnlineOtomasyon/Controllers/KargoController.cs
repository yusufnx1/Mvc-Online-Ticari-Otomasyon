using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context c = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = kod;


            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay p)
        {
            c.KargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}