using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapıMarket2.Models.entity;

namespace YapıMarket2.Controllers
{
    public class urunController : Controller
    {
        YapıMarket1Entities ra = new YapıMarket1Entities();
        // GET: urun
        public ActionResult Index()
        {
            var degerler = ra.Urunler.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler s1)
        {
            ra.Urunler.Add(s1);
            ra.SaveChanges();
            return View();


        }
        public ActionResult SİL(int id)
        {
            var urun = ra.Urunler.Find(id);
            ra.Urunler.Remove(urun);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id) 
        {
            var urun = ra.Urunler.Find(id);
            return View("UrunGetir", urun);

        }
        public ActionResult GÜNCELLE(Urunler p1) 
        {
            var urun = ra.Urunler.Find(p1.UrunID);
            urun.UrunID = p1.UrunID;
            urun.UrunAD = p1.UrunAD;
            urun.UrunKategori = p1.UrunKategori;
            urun.Marka = p1.Marka;
            urun.Fiyat = p1.Fiyat;
            urun.Stok = p1.Stok;
            ra.SaveChanges();
            return RedirectToAction("Index");
        
        }

    }
}