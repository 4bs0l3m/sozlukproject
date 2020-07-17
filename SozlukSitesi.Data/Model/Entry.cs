using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.Model
{
    [Table("Entry")]
    public class Entry
    {
        [Display(Name = "Entry ID")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Entry Başlık")]
        [Required]
        public Baslik Baslik { get; set; }

        [Display(Name = "Entry Sahibi")]
        public virtual Kullanici eSahibi { get; set; }

        [Display(Name = "Giriş Tarihi")]
        public DateTime girisTarihi { get; set; }

        [MinLength(2, ErrorMessage = "Lütfen 2 karakterden fazla giriniz!")]
        [Display(Name = "Entry Metin")]
        [Required]
        public string Metin { get; set; }

        [Display(Name = "Entry Kısa Metin")]
        [Required]
        public string kisaMetin { get; set; }

        [Display(Name = "Like")]
        public int Like { get; set; }

        [Display(Name = "Hate")]
        public int Hate { get; set; }
    }
}
