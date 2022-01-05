using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapıMarket2.Models.entity;

namespace YapıMarket2.Controllers
{
    public class musteriController : Controller

    {
        YapıMarket1Entities ra = new YapıMarket1Entities();
        // GET: musteri
        public ActionResult Index()
        {
            var degerler = ra.Musteriler.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteriler f1)
        {
            ra.Musteriler.Add(f1);
            ra.SaveChanges();
            return View();
        }
        public ActionResult SİL(int id)
        {
            var musteri = ra.Musteriler.Find(id);
            ra.Musteriler.Remove(musteri);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteriler = ra.Musteriler.Find(id);
            return View("MusteriGetir", musteriler);

        }
        public ActionResult GÜNCELLE(Musteriler p1)
        {
            var musteri = ra.Musteriler.Find(p1.MusteriID);
            musteri.MusteriID = p1.MusteriID;
            musteri.MusteriAD = p1.MusteriAD;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            ra.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}