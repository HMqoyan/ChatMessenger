using ChatMessenger.Core.Interfaces.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int entityId);
        Task<TEntity> Create(TEntity entity);
        Task Delete(int entityId);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
