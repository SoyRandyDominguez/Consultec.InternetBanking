using IB.Application.Interfaces.Base;
using IB.Domain.Entities.Base;
using IB.Infraestructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Application.Services.Base
{
    public class BaseService<TEntity, T> : IBaseService<TEntity, T> where TEntity : BaseEntity<T> where T : struct
    {
        protected readonly IBaseRepository<TEntity, T> _baseRepo;
        public BaseService(IBaseRepository<TEntity, T> baseRepo)
        {
            this._baseRepo = baseRepo;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await this._baseRepo.CreateAsync(entity);
        }

        public async Task DeleteAsync(T id)
        {
            await this._baseRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._baseRepo.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllFilterAsync(Func<TEntity, bool> predicate)
        {
            return await this._baseRepo.GetAllFilterAsync(predicate);
        }

        public async Task<TEntity> GetByPKAsync(T id)
        {
            return await this._baseRepo.GetByPKAsync(id);
        }

        public async Task UpdateAsync(T id, TEntity entity)
        {
            await this._baseRepo.UpdateAsync(id, entity);
        }
    }
}
