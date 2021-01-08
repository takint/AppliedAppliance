using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new()
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;
        protected ApplicationDbContext dbContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }

        public TKey Create(TEntity entity)
        {
            dbSet.Add(entity);
            SaveChanges();
            return entity.Id;
        }

        public async Task<TKey> CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public bool Delete(TKey id, bool isSoftDelete = true)
        {
            TEntity entity = dbSet.Find(id);

            if (!isSoftDelete)
            {
                dbSet.Remove(entity);
            }
            else
            {
                entity.Deleted = true;
                dbSet.Update(entity);
            }

            return dbContext.SaveChanges() != 0;
        }

        public async Task<bool> DeleteAsync(TKey id, bool isSoftDelete = true)
        {
            TEntity entity = await dbSet.FindAsync(id);

            if (!isSoftDelete)
            {
                dbSet.Remove(entity);
            }
            else
            {
                entity.Deleted = true;
                dbSet.Update(entity);
            }

            int rows = await dbContext.SaveChangesAsync();

            return rows != 0;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public TEntity GetById(TKey id)
        {
            TEntity entity = dbSet.Find(id);
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            TEntity entity = await dbSet.FindAsync(id);
            return entity;
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public long RecordsCount()
        {
            return dbSet.Count();
        }

        public async Task<long> RecordsCountAsync()
        {
            return await dbSet.CountAsync();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public int SaveChanges()
        {
            ProcessAuditable();
            var result = dbContext.SaveChanges();
            Task.FromResult(DispatchEvents());
            return result;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ProcessAuditable();
            var result = await dbContext.SaveChangesAsync(cancellationToken);
            await DispatchEvents();
            return result;
        }

        private void ProcessAuditable()
        {
            foreach (EntityEntry<AuditableEntity> entry in dbContext.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
        }

        private async Task DispatchEvents()
        {
            var domainEventEntities = dbContext.ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished);

            foreach (var domainEvent in domainEventEntities)
            {
                domainEvent.IsPublished = true;
                await _domainEventService.Publish(domainEvent);
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
