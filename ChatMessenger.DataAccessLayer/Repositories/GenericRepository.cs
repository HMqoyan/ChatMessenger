using ChatMessenger.Core.Interfaces.Models.Db;
using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatMessenger.DataAccessLayer.Repositories
{
    internal abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity
        : class, IEntity
    {
        protected readonly ChatMessengerDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ChatMessengerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public virtual async Task Delete(int entityId)
        {
            TEntity entityToDelete = await GetByIdAsync(entityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Deleted)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
