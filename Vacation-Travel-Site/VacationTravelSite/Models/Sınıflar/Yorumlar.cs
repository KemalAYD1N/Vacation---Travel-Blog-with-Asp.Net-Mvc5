using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationTravelSite.Models.Sınıflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int BlogId { get; set; }
        //yorum ekledikçe yeni bir blog oluşturmasın diye virtual anahtar kelimesini kullandık. Aslında çalışır ama gereksiz veri üretir.
        public virtual Blog Blog { get; set; }//bir yorum sadece 1 bloga ayit olabilir.
    }
}