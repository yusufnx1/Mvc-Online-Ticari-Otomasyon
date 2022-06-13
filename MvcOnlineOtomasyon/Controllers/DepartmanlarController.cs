using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class DepartmanlarController : Controller
    {
        Context c = new Context();
        // GET: Departmanlar
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            d.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);         //id ile değişkeni yakaladık
            dep.Durum = false;                      //database de durumu false yapıyoruz
            c.SaveChanges();                        // değişiklikler kaydedildi
            return RedirectToAction("Index");       //index action'nuna gönderildi
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var dept = c.Departmen.Find(id);
            return View(dept);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dep = c.Departmen.Find(p.DepartmanId);
            dep.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            return View(degerler);
        }
        public ActionResult DepPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var per = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}