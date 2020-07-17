using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SozlukProje.Models
{
    public class Kullanici
    {
        public int ID{ get; set; }
        public string Ad{ get; set; }
        public string Soyad{ get; set; }
        public string eMail { get; set; }
        public DateTime kayitTarihi{ get; set; }
        public List<Kullanici> Arkadaslar{ get; set; }

    }
}