using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);              //Cariler ekleme işlemi yapıldı.
            c.SaveChanges();                // değişiklikler kaydedildi.
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var dept = c.Carilers.Find(id);
            return View(dept);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cariler p)
        {
            var dep = c.Carilers.Find(p.CariId);
            dep.CariAd = p.CariAd;
            dep.CariSoyad = p.CariSoyad;
            dep.CariSehir = p.CariSehir;
            dep.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = c.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.Cari = cari;
            return View(deger);
        }
    }
}