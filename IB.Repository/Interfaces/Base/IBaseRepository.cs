using IB.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Infraestructure.Interfaces.Base
{
    public interface IBaseRepository<TEntity, T> where TEntity : IBaseEntity<T> where T : struct
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllFilterAsync(Func<TEntity, bool> predicate);
        Task<TEntity> GetByPKAsync(T id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(T id, TEntity entity);
        Task DeleteAsync(T id);
        Task CreateMultipleAsync(IEnumerable<TEntity> entities);
        Task UpdateMultipleAsync(IEnumerable<TEntity> entities);
        Task AddOrUpdateAsync(TEntity entity);
    }
}
