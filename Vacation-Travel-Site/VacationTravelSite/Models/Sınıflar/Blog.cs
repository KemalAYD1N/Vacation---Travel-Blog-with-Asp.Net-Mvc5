using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationTravelSite.Models.Sınıflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }

        //bir blogun birden fazla yorumu olabilir.
        public ICollection<Yorumlar>Yorumlars { get; set; } // yorumlar sınıfı ile 1 to many ilişki kurulur


    }
}