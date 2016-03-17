using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;

namespace TravelPortal.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void AttachRange(IList<T> entities)
        {
            _dbSet.AttachRange(entities);
            _context.Entry(entities).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            var detached = entities.Where(entity => _context.Entry(entity).State == EntityState.Detached);
            _dbSet.AttachRange((detached));

            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
