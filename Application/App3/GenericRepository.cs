using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Application.App3
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
        }

        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }

        public void Edit(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
