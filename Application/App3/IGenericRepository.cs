using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.App3
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Find(Expression<Func<T, bool>> predicate);
        void Add(T Entity);
        void Delete(T Entity);
        void Edit(T Entity);
        void SaveChanges();
    }
}
