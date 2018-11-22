using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.App9
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> Predicate);
        IQueryable<T> GetAll();
        void Add(T Entity);        
    }
}
