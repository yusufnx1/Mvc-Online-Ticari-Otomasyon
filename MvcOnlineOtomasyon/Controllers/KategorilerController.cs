using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineOtomasyon.Controllers
{
    public class KategorilerController : Controller
    {
        Context c = new Context(); //databaseden nesne türettik
        // GET: Kategoriler
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,5); //kategorileri listeledik
            return View(degerler); //degerler ekranda gösterildi
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();  //degerler ekrana yazdırıldı.
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori p)
        {
            c.Kategoris.Add(p); //kategori ekleme işlemi yapıldı.
            c.SaveChanges();    // değişiklikler kaydedildi.
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id); //id ile değişkeni yakaladık
            c.Kategoris.Remove(ktg);    //remove ile silme işlemi yaptık
            c.SaveChanges();            // değişiklikler kaydedildi
            return RedirectToAction("Index"); //index action'nuna gönderildi
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = c.Kategoris.Find(id);     // guncelleme yapılacak deger bulundu id ile
            return View("KategoriGetir",ktg);   // degeri view'e taşıdık 
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriId); // guncellenecek değikşeni bulduk
            kategori.KategoriAd = k.KategoriAd; // database ile dışarıdan girilen değeri eşleştirdik
            c.SaveChanges();                    // değişiklikler kaydedildi
            return RedirectToAction("Index");   // index action'nuna gönderildi.
        }
    }
}