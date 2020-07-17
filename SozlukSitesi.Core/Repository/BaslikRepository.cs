using SozlukSitesi.Core.İnfastructure;
using SozlukSitesi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace SozlukSitesi.Core.Repository
{
    public class BaslikRepository : IBaslikRepository
    {
        SozlukContext _context = DataModel.Context;
        public IEnumerable<Data.Model.Baslik> GetAll()
        {
            return _context.Baslik.Select(x => x);
        }

        public Data.Model.Baslik GetById(int ID)
        {
            return _context.Baslik.FirstOrDefault(x => x.ID == ID);
        }

        public Data.Model.Baslik Get(System.Linq.Expressions.Expression<Func<Data.Model.Baslik, bool>> expression)
        {
            return _context.Baslik.FirstOrDefault(expression);
        }
        public IQueryable<Data.Model.Baslik> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Baslik, bool>> expression)
        {
            return _context.Baslik.Where(expression);
        }

        public void Insert(Data.Model.Baslik obj)
        {
            _context.Baslik.Add(obj);
        }

        public void Update(Data.Model.Baslik obj)
        {
            _context.Baslik.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var Baslik = GetById(id);
            if (Baslik != null)
            {
                _context.Baslik.Remove(Baslik);
            }
        }

        public int Count()
        {
            return _context.Baslik.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
