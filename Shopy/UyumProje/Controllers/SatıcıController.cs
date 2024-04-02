using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UyumProje.Models;


namespace UyumProje.Controllers
{
    public class SatıcıController : Controller
    {
        // GET: Satıcı
        SHOPEntities2 model = new SHOPEntities2();
        
        public ActionResult Satıcı()
        {
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            List<Ürünler> Ürünler = model.Ürünler.ToList();
            List<Ürün> Ürün = model.Ürün.ToList();
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            List<Manken> Manken = model.Manken.ToList();
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            ViewBag.Tasarımcı = Tasarımcı;
            ViewBag.Manken = Manken;   
            ViewBag.ÜrünBeden = ÜrünBeden;
            ViewBag.Ürünler = Ürünler;
            ViewBag.ÜrünTürü = ÜrünTürü;
            return View(Ürün);
        }

        

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<Ürün> Ürün = model.Ürün.ToList();
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            List<KULLANICI> KULLANICI = model.KULLANICI.ToList();
            List<BileşenOranı> BileşenOranı = model.BileşenOranı.ToList();
            Ürün u =  new Ürün();
            List<KullanıcıTürü> KullanıcıTürü = model.KullanıcıTürü.ToList();
            List<Manken> Manken = model.Manken.ToList();
            ViewBag.Manken = Manken;
            ViewBag.KullanıcıTürü = KullanıcıTürü;
            
            ViewBag.BileşenOranı = BileşenOranı;
            ViewBag.KULLANICI = KULLANICI;
            ViewBag.Tasarımcı = Tasarımcı;
            ViewBag.ÜrünTürü = ÜrünTürü;
            ViewBag.Ürün = Ürün;
            ViewBag.ÜrünBeden = ÜrünBeden;
            return View(u);
        }

        [HttpGet]
        public ActionResult MankenEkle()
        {
            Manken m = new Manken();
            List<Manken> manken = model.Manken.ToList();
            ViewBag.Manken = manken;
            List<Beden> beden = model.Beden.ToList();
            ViewBag.Beden = beden;

            return View(m);
        }

        

        
        public ActionResult StokEkle(int id=0)
        {
            
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            ViewBag.ÜrünBeden = ÜrünBeden;
            List<Ürün> Ürün = model.Ürün.ToList();
            ViewBag.Ürün = Ürün;
            ViewBag.id = id;

            return View();
        }

        [HttpGet]
        public ActionResult TürEkle()
        {

            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            ViewBag.ÜrünBeden = ÜrünTürü;
            return View();
        }

        [HttpGet]
        public ActionResult Order()
        {
            List<Ürün> Ürün = model.Ürün.ToList();
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            List<KULLANICI> KULLANICI = model.KULLANICI.ToList();
            List<BileşenOranı> BileşenOranı = model.BileşenOranı.ToList();
            List<KullanıcıTürü> KullanıcıTürü = model.KullanıcıTürü.ToList();
            



            ViewBag.KullanıcıTürü = KullanıcıTürü;
            ViewBag.BileşenOranı = BileşenOranı;
            ViewBag.KULLANICI = KULLANICI;
            ViewBag.Tasarımcı = Tasarımcı;
            ViewBag.ÜrünTürü = ÜrünTürü;
            ViewBag.Ürün = Ürün;
            ViewBag.ÜrünBeden = ÜrünBeden;

            return View();
        }
        
        [HttpPost]

        public JsonResult SıparisEkle(int[] siparis)
        {
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            Sipariş k = new Sipariş();
            foreach(ÜrünBeden ürüns in ÜrünBeden){
                if (ürüns.ürünID ==siparis[3]&& ürüns.BedenID == siparis[1])
                {
                    k.ürünBedenID = ürüns.ürünBedenID;
                    k.kullanıcıID = siparis[0];
                    k.tutar = siparis[2];
                    model.Sipariş.Add(k);
                }
            }
            
            model.SaveChanges();
            return Json(k);
        }


        [HttpPost]

        public JsonResult AjaxMethod(Ürün urun)
        {

            model.Ürün.AddOrUpdate(urun);
            model.SaveChanges();
            return Json(urun);
        }

        [HttpPost]

        public JsonResult StokEkle(int[] stok)
        {
            int id = stok[3];
            for(int i = 0; i < stok.Length-1; i++)
            {
                ÜrünBeden ürünbeden = new ÜrünBeden();
                ürünbeden.stokMiktarı = stok[i];
                ürünbeden.BedenID = i + 1;
                ürünbeden.ürünID = id;
                model.ÜrünBeden.Add(ürünbeden);
            }
            
            model.SaveChanges();
            return Json(stok);
        }

        [HttpPost]

        public JsonResult TurEkle(ÜrünTürü tur)
        {

            model.ÜrünTürü.AddOrUpdate(tur);
            model.SaveChanges();
            return Json(tur);
        }

        [HttpPost]

        public JsonResult MankenEkle(Manken manken)
        {
            
            model.Manken.AddOrUpdate(manken);
            model.SaveChanges();
            return Json(manken);
        }

        [HttpGet]
        
        public ActionResult UrunGuncelle(int id)
        {
            Ürün urun = model.Ürün.FirstOrDefault(x => x.ürünID == id);
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            List<BileşenOranı> BileşenOranı = model.BileşenOranı.ToList();
            List<Manken> Manken = model.Manken.ToList();
            ViewBag.Manken = Manken;
            ViewBag.ÜrünTürü = ÜrünTürü;
            ViewBag.Tasarımcı = Tasarımcı;
            ViewBag.BileşenOranı = BileşenOranı;
            if (urun != null)
            {
                return View("UrunEkle", urun);
            }
            return null;
        }

        [HttpPost]

        public void UrunSil(int id)
        {
            Ürün b = model.Ürün.FirstOrDefault(x => x.ürünID == id);
            if (b != null)
            {
                model.Ürün.Remove(b);
                model.SaveChanges();
            }
                

        }
    }
}

