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
    public class EntryRepository : IEntryRepository
    {
        SozlukContext _context = DataModel.Context;
        public IEnumerable<Data.Model.Entry> GetAll()
        {
            return _context.Entry.Select(x => x);
        }

        public Data.Model.Entry GetById(int ID)
        {
            return _context.Entry.FirstOrDefault(x => x.ID == ID);
        }

        public Data.Model.Entry Get(System.Linq.Expressions.Expression<Func<Data.Model.Entry, bool>> expression)
        {
            return _context.Entry.FirstOrDefault(expression);
        }
        public IQueryable<Data.Model.Entry> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Entry, bool>> expression)
        {
            return _context.Entry.Where(expression);
        }

        public void Insert(Data.Model.Entry obj)
        {
            _context.Entry.Add(obj);
        }

        public void Update(Data.Model.Entry obj)
        {
            _context.Entry.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var Entry = GetById(id);
            if (Entry != null)
            {
                _context.Entry.Remove(Entry);
            }
        }

        public int Count()
        {
            return _context.Entry.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
