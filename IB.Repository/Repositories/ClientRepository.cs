using IB.Domain.Context;
using IB.Domain.Entities;
using IB.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        protected readonly IBContext _dbContext;
        public ClientRepository(IBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Client> Create(Client entity)
        {
            var newEntity = _dbContext.Set<Client>().Add(entity);
            await _dbContext.SaveChangesAsync();

            var retrievedEntity = await newEntity.GetDatabaseValuesAsync();
            return retrievedEntity.ToObject() as Client;
        }

        public async Task<List<Client>> GetClients()
        {
            return await _dbContext.Set<Client>()
                       .Include(x => x.Accounts)
                       .AsNoTracking().ToListAsync();

        }
    }
}
