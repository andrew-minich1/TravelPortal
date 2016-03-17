using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelPortal.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Initialize();
        void SaveChanges();
        IRepository<T> Repository<T>() where T : class;
        IQueryable<T> Entity<T>() where T : class;
        IQueryable<T> Entity<T>(params Expression<Func<T, object>>[] navigations) where T : class;
    }
}
