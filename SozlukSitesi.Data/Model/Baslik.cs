using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.Model
{
    [Table("Baslik")]
   public class Baslik
    {
        [Display(Name = "Baslık ID")]
        [Key]
        public int ID { get; set; }

        [MinLength(2, ErrorMessage = "Lütfen 2 karakterden fazla giriniz!"),
         MaxLength(50, ErrorMessage = "Lütfen 50 karakterden fazla girmeyiniz!")]
        [Display(Name = "Baslık Adı")]
        [Required]
        public string Ad { get; set; }

        [Display(Name = "Yayın Tarihi")]
        public DateTime YayinTarihi { get; set; }

        [Display(Name = "Like")]
        public int Like { get; set; }

        [Display(Name = "Hate")]
        public int Hate { get; set; }

        [Display(Name = "Yayınlayan")]
        public Kullanici Yayınlayan { get; set; }
    }
}
