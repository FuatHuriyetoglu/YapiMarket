using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YapıMarket2.Models.entity;

namespace YapıMarket2.Controllers
{
    public class SecurityController : Controller
    {
        YapıMarket1Entities ra = new YapıMarket1Entities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User kullanici)
        {



            var kullaniciInDb = ra.User.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Geçersiz kullanıcı adı veya parola";
                return View();
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}