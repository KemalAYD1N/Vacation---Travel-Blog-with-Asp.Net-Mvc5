using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationTravelSite.Models.Sınıflar;

namespace VacationTravelSite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();

            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();

            return PartialView(degerler);
        }
        
        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();

            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var degerler = c.Blogs.Take(6).ToList();

            return PartialView(degerler);
        }
    }
}