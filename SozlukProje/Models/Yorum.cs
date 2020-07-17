using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukProje.Models
{
    public class Yorum
    {
        public int ID{ get; set; }
        public Kullanici Gonderen{ get; set; }
        public Konu Gonderilen { get; set; }
        public DateTime gonderimTarihi{ get; set; }
        public int Like{ get; set; }
        public int Dislike{ get; set; }

    }
}