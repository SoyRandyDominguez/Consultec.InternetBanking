using IB.Domain.Context;
using IB.Domain.Entities;
using IB.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace IB.Infraestructure.Repositories.Base
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        protected readonly IBContext dbContext;
        public ClientRepository(IBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Client> Create(Client entity)
        {
            var newEntity = dbContext.Set<Client>().Add(entity);
            await dbContext.SaveChangesAsync();

            var retrievedEntity = await newEntity.GetDatabaseValuesAsync();
            return retrievedEntity.ToObject() as Client;
        }

        public Task<List<Client>> GetClients()
        {
           return _dbContext.Set<Client>().AsNoTracking().ToListAsync();
        }
    }
}
