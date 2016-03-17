using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Entity;
using TravelPortal.Data.Infrastructure;

namespace TravelPortal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _disposed;
        private string _connectionString = "Data Source=DESKTOP-JS6LTPO\\SQLEXPRESS;Initial Catalog=TravelPortal;Min Pool Size=0;Max Pool Size=200;MultipleActiveResultSets=True;Persist Security Info=True\" providerName=\"System.Data.SqlClient";

        public bool IsInitialized
        {
            get { return _context != null; }
        }

        public void Initialize()
        {
            _context = new EfDbContext(_connectionString);
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public IQueryable<T> Entity<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Entity<T>(params Expression<Func<T, object>>[] navigations) where T : class
        {
            IQueryable<T> query = _context.Set<T>();

            if (navigations == null || navigations.Length == 0)
            {
                return query;
            }

            return navigations.Aggregate(query, (current, navigation) => current.Include(navigation));
        }

        public void SaveChanges()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_context != null && disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
