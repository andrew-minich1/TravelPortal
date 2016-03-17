using System.Collections.Generic;

namespace TravelPortal.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IList<T> entities);

        void Delete(T entity);
        void DeleteRange(IList<T> entities);

        void Attach(T entity);
        void AttachRange(IList<T> entities);
    }
}
