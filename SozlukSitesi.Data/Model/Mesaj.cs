using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.Model
{
    [Table("Mesaj")]
    public class Mesaj
    {
        [Display(Name = "Mesaj ID")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Gönderen")]
        public Kullanici Gonderen { get; set; }

        [Display(Name = "Alan")]
        public Kullanici Alan { get; set; }

        [Display(Name = "Goruldu")]
        public bool Goruldu { get; set; }

        [Display(Name = "Gonderim Tarihi")]
        public DateTime GonderimTarihi { get; set; }

        [Display(Name = "Mesaj Metin")]
        public string Metin { get; set; }
    }
}
