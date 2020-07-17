using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.Model
{
    [Table("Kullanici")]
   public class Kullanici
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Ad")]
        [MaxLength(50,  ErrorMessage = "Lütfen 50 karakterden fazla girmeyiniz!")]
        [Required]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakterden fazla girmeyiniz!")]
        [Required]
        public string Soyad { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(20, ErrorMessage = "Lütfen 20 karakterden fazla girmeyiniz!")]
        [Required]
        public string KullaniciAdi { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Required]
     //   [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$)",
        //    ErrorMessage="Lütfen geçerli bir E-Posta giriniz.")]
        public string eMail { get; set; }

        [Display(Name = "Şifre")]
        [MaxLength(16, ErrorMessage = "Lütfen 16 karakterden fazla girmeyiniz!")]
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }

        [Display(Name = "eMail_Onay")]
        public bool eMail_Onay { get; set; }

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; }

        [Display(Name = "Rol")]
        public virtual Rol Rol { get; set; }

        [Display(Name = "Cinsiyet")]
        [MaxLength(5, ErrorMessage = "Lütfen 5 karakterden fazla girmeyiniz!")]
        public string Cinsiyet{ get; set; }
    }
}
