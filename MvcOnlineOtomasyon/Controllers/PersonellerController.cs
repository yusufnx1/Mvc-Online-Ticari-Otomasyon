using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineOtomasyon.Models.Sınıflar;

namespace MvcOnlineOtomasyon.Controllers
{
    public class PersonellerController : Controller
    {
        // GET: Personeller
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> dgr1 = (from x in c.Departmen.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()

                                         }).ToList();
            ViewBag.dgr1 = dgr1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelImage = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dep = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelImage = "/Image/" + dosyaadi + uzanti;
            }
            var prsln = c.Personels.Find(p.PersonelId);
            prsln.PersonelAd = p.PersonelAd;
            prsln.PersonelSoyad = p.PersonelSoyad;
            prsln.PersonelImage = p.PersonelImage;
            prsln.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelLite()
        {
            var list = c.Personels.ToList();
            return View(list);
        }
    }
}