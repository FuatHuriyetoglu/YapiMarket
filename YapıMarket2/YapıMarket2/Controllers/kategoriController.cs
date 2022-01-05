using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapıMarket2.Models.entity;

namespace YapıMarket2.Controllers
{
    public class kategoriController : Controller
    {
        YapıMarket1Entities ra = new YapıMarket1Entities();
        // GET: kategori
        public ActionResult Index()
        {
            var degerler = ra.Kategoriler.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler s1)
        {
            ra.Kategoriler.Add(s1);
            ra.SaveChanges();
            return View();


        }
        public ActionResult SİL(int id)
        {
            var kategori = ra.Kategoriler.Find(id);
            ra.Kategoriler.Remove(kategori);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = ra.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);

        }
        public ActionResult GÜNCELLE(Kategoriler p1)
        {
            var kategori = ra.Kategoriler.Find(p1.KategoriID);
            kategori.KategoriID = p1.KategoriID;
            kategori.KategoriAD = p1.KategoriAD;
            ra.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}