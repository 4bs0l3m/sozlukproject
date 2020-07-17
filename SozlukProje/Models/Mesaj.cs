using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukProje.Models
{
    public class Mesaj
    {
        public int ID{ get; set; }
        public Kullanici Alici { get; set; }
        public Kullanici Verici{ get; set; }
        public string Metin{ get; set; }
        public DateTime gonderimTarihi{ get; set; }

    }
}