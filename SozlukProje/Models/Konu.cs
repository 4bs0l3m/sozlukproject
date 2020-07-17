using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukProje.Models
{
    public class Konu
    {
        public int ID{ get; set; }
        public string Baslik{ get; set; }
        public DateTime yayinTarihi { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public Kullanici Yazar{ get; set; }
    }
}