using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationTravelSite.Models.Sınıflar;

namespace VacationTravelSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bg = c.Blogs.Find(id);

            return View("BlogGetir", bg);  
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var bg = c.Blogs.Find(b.ID);
            bg.Aciklama = b.Aciklama;
            bg.Baslik = b.Baslik;
            bg.BlogImage = b.BlogImage;
            bg.Tarih = b.Tarih;

            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult YorumListele()
        {
            var yl = c.Yorumlars.ToList();

            return View(yl);
        }

        public ActionResult YorumSil(int id)
        {
            var yr = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yr);
            c.SaveChanges();

            return RedirectToAction("YorumListele");
        }

        public ActionResult YorumGetir(int id)
        {
            var yg = c.Yorumlars.Find(id);

            return View("YorumGetir", yg);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yg = c.Yorumlars.Find(y.ID);

            yg.KullaniciAdi = y.KullaniciAdi;
            yg.Mail = y.Mail;
            yg.Yorum = y.Yorum;

            c.SaveChanges();

            return RedirectToAction("YorumListele");
        }
    }
}