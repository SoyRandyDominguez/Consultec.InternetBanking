using IB.Domain.Context;
using IB.Domain.Entities.Base;
using IB.Infraestructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IB.Infraestructure.Repositories.Base
{
    public class BaseRepository<TEntity, T> : IBaseRepository<TEntity, T> where TEntity : BaseEntity<T> where T : struct
    {
        protected readonly IBContext _dbContext;
        protected const bool _isInactive = false;
        public BaseRepository(IBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func)
        {
            return func(_dbContext.Set<TEntity>()).AsQueryable();
        }
        public async virtual Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async virtual Task DeleteAsync(T id)
        {
            var entity = await GetByPKAsync(id);
            if (Equals(entity, null) == false)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new DbUpdateException($"Not Found PK {id} para la entidad {typeof(TEntity)}");
            }
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async virtual Task<IEnumerable<TEntity>> GetAllFilterAsync(Func<TEntity, bool> predicate)
        {
            if (Equals(predicate, null) == false)
            {
                return _dbContext.Set<TEntity>().Where(predicate).ToList();
            }
            else
            {
                return await this.GetAllAsync();
            }
        }
        public async virtual Task<TEntity> GetByPKAsync(T id)
        {

            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
        public async virtual Task UpdateAsync(T id, TEntity entity)
        {
            var entityToUpdate = await this.GetByPKAsync(id);
            if (!Equals(entityToUpdate, null))
            {
                List<PropertyInfo> properties = entity.GetType().GetProperties().ToList();
                properties.ForEach(
                    prop =>
                    {
                        if (prop.Name != nameof(IBaseEntity<T>.Id))
                        {
                            var newValue = entity.GetType().GetProperty(prop.Name)?.GetValue(entity);
                            entityToUpdate.GetType().GetProperty(prop.Name)?.SetValue(entityToUpdate, newValue);
                        }
                    }
                );
                _dbContext.Set<TEntity>().Update(entityToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new DbUpdateException($"Not Found PK {id} para la entidad {typeof(TEntity)}");
            }
        }
        public async virtual Task AddOrUpdateAsync(TEntity entity)
        {
            if (Equals(entity, null))
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async virtual Task CreateMultipleAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        public async virtual Task UpdateMultipleAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
