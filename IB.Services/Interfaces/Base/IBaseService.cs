using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IB.Application.Interfaces.Base
{
    public interface IBaseService<TEntity, T>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllFilterAsync(Func<TEntity, bool> predicate);

        Task<TEntity> GetByPKAsync(T id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(T id, TEntity entity);

        Task DeleteAsync(T id);
    }
}
