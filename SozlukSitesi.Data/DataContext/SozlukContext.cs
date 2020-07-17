using SozlukSitesi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Data.DataContext
{
    public class SozlukContext : DbContext
    {
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Baslik> Baslik { get; set; }
        public DbSet<Mesaj> Mesaj { get; set; }
    }
}
