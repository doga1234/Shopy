using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UyumProje.Models;

namespace UyumProje.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        SHOPEntities2 model = new SHOPEntities2();
        public ActionResult Index(int id=-1)
        {
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            ViewBag.ÜrünTürü = ÜrünTürü;
            List<Ürünler> list = model.Ürünler.ToList();
            List<Ürün> Ürün = model.Ürün.ToList();
            List<BileşenOranı> BileşenOranı = model.BileşenOranı.ToList();
            ViewBag.Ürün = Ürün;
            ViewBag.BileşenOranı = BileşenOranı;
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            ViewBag.Tasarımcı = Tasarımcı;
            Tasarımcı u = model.Tasarımcı.FirstOrDefault(x => x.tasarımcıID == id);
            ViewBag.u = u;
            
            return View(u);
        }

        public ActionResult Urunler(int id=-1)
        {
            List<Ürün> Ürün = model.Ürün.ToList();
            List<Ürünler> Ürünler = model.Ürünler.ToList();
            List<ÜrünTürü> ÜrünTürü = model.ÜrünTürü.ToList();
            List<ÜrünBeden> ÜrünBeden = model.ÜrünBeden.ToList();
            List<Tasarımcı> Tasarımcı = model.Tasarımcı.ToList();
            ViewBag.Tasarımcı = Tasarımcı;
            
            ÜrünTürü u = model.ÜrünTürü.FirstOrDefault(x => x.ürünTürüID == id);
            ViewBag.ÜrünTürü = ÜrünTürü;
            ViewBag.u = u;          
            ViewBag.Ürünler = Ürünler;           
            ViewBag.Ürün = Ürün;
            ViewBag.ÜrünBeden = ÜrünBeden;
            
            return View(u);
        }
    }
}