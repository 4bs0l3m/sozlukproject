using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SozlukSitesi.Core.İnfastructure
{
  public  interface IRepository<T> where T:class
    {
      //Tüm datayı çekecek
      IEnumerable<T> GetAll();
      //
      T GetById(int ID);
      T Get(Expression<Func<T, bool>> expression);
      IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
      void Insert(T obj);
      void Update(T obj);
      void Delete(int id);
      int Count();
      void Save();
    }
}
