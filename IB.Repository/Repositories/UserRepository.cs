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
    public class UserRepository : IUserRepository
    {
        protected readonly IBContext _dbContext;
        public UserRepository(IBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> Create(User entity)
        {
            var newEntity = _dbContext.Set<User>().Add(entity);
            await _dbContext.SaveChangesAsync();

            var retrievedEntity = await newEntity.GetDatabaseValuesAsync();
            return retrievedEntity.ToObject() as User;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Set<User>()
                       .Include(x => x.Client)
                        .ThenInclude(x=> x.Accounts)
                       .AsNoTracking().ToListAsync();

        }
    }
}
