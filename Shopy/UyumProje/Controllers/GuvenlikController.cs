using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UyumProje.Models;
using System.Web.Security;
using System.Runtime.Remoting.Contexts;

namespace UyumProje.Controllers
{
   
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik

        SHOPEntities2 model = new SHOPEntities2();
        [AllowAnonymous]
        [HttpGet]
        
        public ActionResult Login(int id = 1)
        {
            List<Cinsiyet> Cinsiyet = model.Cinsiyet.ToList();
            List<KullanıcıTürü> KullanıcıTürü = model.KullanıcıTürü.ToList();
            ViewBag.KullanıcıTürü = KullanıcıTürü;
            ViewBag.Cinsiyet = Cinsiyet;
            ViewBag.id = id;
            return View();
        }

        
           
        [HttpPost]
        public JsonResult Login(KULLANICI kullanici)
        {

            KULLANICI found = model.KULLANICI.FirstOrDefault(x => x.Ad == kullanici.Ad && x.şifre == kullanici.şifre);
            string result = "fail";
            if (found != null)
            {
                Session["username"] = found.Ad;
                Session["rol"] = found.kullanıcıTürüID.ToString();
                Session["id"] = found.kullanıcıID.ToString();
    
                result = found.kullanıcıTürüID.ToString();
                FormsAuthentication.SetAuthCookie(found.kullanıcıTürüID.ToString(), false);
            }
            return Json(result, JsonRequestBehavior.AllowGet);      
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult AjaxMethod(KULLANICI kullanici)
        {
            //Kullanıcı ekle
            model.KULLANICI.Add(kullanici);
            model.SaveChanges();
            return Json(kullanici);
        }

        [HttpPost]

        public JsonResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Json("");
        }



    }
}