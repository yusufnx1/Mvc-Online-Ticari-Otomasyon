using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class UrunlerController : Controller
    {
        Context c = new Context();   //Baglantıdan nesne oluşturduk
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();     // durumu true olan urunleri listeledik var ile getiye döndürüyoruz
            return View(urunler);               // geriye urunleri dondursun.
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {                                            // dropdonw ile ilişkili tabloya veri çekme
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;      // view'e veri taşıyoruz
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);                     //Urun ekledik u dan gelen degerle
            u.Durum = true;
            c.SaveChanges();                    // değikişlikleri kaydettik
            return RedirectToAction("Index");   //Index'e gönder
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);       //ürünü idsine göre buluyoruz
            deger.Durum = false;                // veri tabanında durumunu false yapıyoruz
            c.SaveChanges();                    //değişiklikleri veri tabanına kaydediyoruz
            return RedirectToAction("Index");   // index actionuna gönderiyoruz 
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {                                            // dropdonw ile ilişkili tabloya veri çekme
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;                                                          // view'e veri taşıyoruz
            var urundeger = c.Uruns.Find(id);                                           // urunu idsine göre bulma
            return View("UrunGetir", urundeger);                                         // geriye urungetir view ile buldugumuz idyi getiriyoruz
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunId);                   //ürünü idsine göre buluyoruz
            urn.AlisFiyat = p.AlisFiyat;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Durum = p.Durum;
            urn.KategoriId = p.KategoriId;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();                                    //değişiklikleri veri tabanına kaydediyoruz
            return RedirectToAction("Index");                   // index actionuna gönderiyoruz 
        }
        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger2 = c.Uruns.Find(id);
            ViewBag.dgr2 = deger2.UrunId;
            ViewBag.dgr2 = deger2.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket Sh)
        {
            Sh.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(Sh);
            c.SaveChanges();
            return RedirectToAction("Index","Satislar");
        }
    }
}