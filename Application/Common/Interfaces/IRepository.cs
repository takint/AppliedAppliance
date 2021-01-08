using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : BaseEntity<TKey>
    {
        Task<TKey> CreateAsync(TEntity entity);
        TKey Create(TEntity entity);

        Task UpdateAsync(TEntity entity);
        void Update(TEntity entity);

        Task<bool> DeleteAsync(TKey id, bool isSoftDelete = true);
        bool Delete(TKey id, bool isSoftDelete = true);

        Task<TEntity> GetByIdAsync(TKey id);
        TEntity GetById(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);

        Task<long> RecordsCountAsync();
        long RecordsCount();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
