using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infrastructure.Database.EF;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.Repository.Abstractions;

namespace Infrastructure.Database.Repository.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region [ Private Field(s) ]

        private readonly PersonReferenceContext _context;

        #endregion

        #region [ Constructor(s) ]

        public GenericRepository(PersonReferenceContext context)
        {
            _context = context;
        }

        #endregion

        #region [ Public Method(s) ]

        public void Delete(object id)
        {
            _context.Remove(id);
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void Delete(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>()
                .ToListAsync(cancellationToken);
        }
        public T GetById(object id, CancellationToken cancellationToken = default)
        {
            return _context.Find<T>(id);
        }
        public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public void Update(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
        }
        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}