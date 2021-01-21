using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationTravelSite.Models.Sınıflar;

namespace VacationTravelSite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        Context c = new Context();  //veri tabanı için
        BlogYorum by = new BlogYorum(); //birden fazla model, torbalanarak bir sınıf içerisinde gönderilir.
        public ActionResult Index()
        {
            by.deger1 = c.Blogs.ToList();//bloglar getirilir

            //by.deger3 = c.Blogs.Take(3).ToList(); //ilk üç blogu getirir
            by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 blog getirilir

            return View(by);
        }
       
        public ActionResult BlogDetay(int id)
        {
            by.deger1 = c.Blogs.Where(x => x.ID == id).ToList(); //bloglar içerisinden id değeri tutan viewe gönderilir

            by.deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList(); //yorumlar içerisinden BlogId değeri tutan viewe gönderilir

            //var blogBul = c.Blogs.Where(x => x.ID == id).ToList();

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        Yorumlar y1 = new Yorumlar();
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            var yor = c.Yorumlars.ToList();
            
            //mevcut yorumlar içerisinde eklenecek olan ile aynı olan var ise yeni yorum eklenmez.
            foreach (var item in yor)
            {
                if (item.Yorum == y.Yorum)
                {
                    return PartialView();
                }
            }
            //aynı yorum daha önceden yapılmamış ise yarum eklenebilir.
            c.Yorumlars.Add(y);
            c.SaveChanges();
            
            return PartialView();
        }
    }
}