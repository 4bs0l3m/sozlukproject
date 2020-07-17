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
    public class RolRepository : IRolRepository
    {
        SozlukContext _context = DataModel.Context;
        public IEnumerable<Data.Model.Rol> GetAll()
        {
            return _context.Rol.Select(x => x);
        }

        public Data.Model.Rol GetById(int ID)
        {
            return _context.Rol.FirstOrDefault(x => x.ID == ID);
        }

        public Data.Model.Rol Get(System.Linq.Expressions.Expression<Func<Data.Model.Rol, bool>> expression)
        {
            return _context.Rol.FirstOrDefault(expression);
        }
        public IQueryable<Data.Model.Rol> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.Rol, bool>> expression)
        {
            return _context.Rol.Where(expression);
        }

        public void Insert(Data.Model.Rol obj)
        {
            _context.Rol.Add(obj);
        }

        public void Update(Data.Model.Rol obj)
        {
            _context.Rol.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol != null)
            {
                _context.Rol.Remove(Rol);
            }
        }

        public int Count()
        {
            return _context.Rol.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
