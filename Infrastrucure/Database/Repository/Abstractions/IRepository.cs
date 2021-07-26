using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Infrastructure.Database.Repository.Abstractions
{
    public interface IRepository<T>
    {
        void Delete(object id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        T GetById(object id, CancellationToken cancellationToken = default);
        Task InsertAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync();
    }
}