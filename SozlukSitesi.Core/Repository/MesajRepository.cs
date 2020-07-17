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
    public class MesajRepository : IMesajRepository
    {
        SozlukContext _context = DataModel.Context;
        public IEnumerable<Data.Model.Mesaj> GetAll()
        {
            return _context.Mesaj.Select(x => x);
        }

        public Data.Model.Mesaj GetById(int ID)
        {
            return _context.Mesaj.FirstOrDefault(x => x.ID == ID);
        }

        public Data.Model.Mesaj Get(System.Linq.Expressions.Expression<Func<Data.Model.Mesaj, bool>> expression)
        {
            return _context.Mesaj.FirstOrDefault(expression);
        }
        public IQueryable<Data.Model.Mesaj> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Mesaj, bool>> expression)
        {
            return _context.Mesaj.Where(expression);
        }

        public void Insert(Data.Model.Mesaj obj)
        {
           
            _context.Mesaj.Add(obj);
        }

        public void Update(Data.Model.Mesaj obj)
        {
            _context.Mesaj.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var Mesaj = GetById(id);
            if (Mesaj != null)
            {
                _context.Mesaj.Remove(Mesaj);
            }
        }

        public int Count()
        {
            return _context.Mesaj.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
