using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VacationTravelSite.Models.Sınıflar;

namespace VacationTravelSite.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);

            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullanici, false);
                Session["Kullanici"] = bilgi.Kullanici.ToString();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "LogIn");
        }
    }
}