using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.Model
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Rol Adi: ")]
        [MinLength(3, ErrorMessage = "Lütfen 3 karakterden fazla giriniz!"),
        MaxLength(150, ErrorMessage = "Lütfen 150 karakterden fazla girmeyiniz!")]
        public string RolAdi { get; set; }

    }
}
