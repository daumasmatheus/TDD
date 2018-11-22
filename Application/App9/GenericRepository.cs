using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.App9
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProductDbContext _context;

        public GenericRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> Predicate)
        {
            return _context.Set<T>().Where(Predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }               
    }
}
