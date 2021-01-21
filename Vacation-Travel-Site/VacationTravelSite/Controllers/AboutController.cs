using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationTravelSite.Models.Sınıflar;

namespace VacationTravelSite.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        Context c = new Context(); //bu sınıf aracılığı ile veri tabanından veri çekilir.
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList(); //hakkımızda sınıfından veri çekiyoruz

            return View(degerler);
        }
    }
}