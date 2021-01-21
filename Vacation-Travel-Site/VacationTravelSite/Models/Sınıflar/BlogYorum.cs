using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationTravelSite.Models.Sınıflar
{
    //birden fazla sınıfı view e taşıyabilmek için sınıf oluşturulur.
    public class BlogYorum
    {
        public IEnumerable<Blog> deger1 { set; get; }
        public IEnumerable<Yorumlar> deger2 { set; get; }
        public IEnumerable<Blog> deger3 { set; get; }
    }
}