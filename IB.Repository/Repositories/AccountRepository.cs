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
    public class AccountRepository : IAccountRepository
    {
        protected readonly IBContext _dbContext;
        public AccountRepository(IBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Account> Create(Account entity)
        {
            var newEntity = _dbContext.Set<Account>().Add(entity);
            await _dbContext.SaveChangesAsync();

            var retrievedEntity = await newEntity.GetDatabaseValuesAsync();
            return retrievedEntity.ToObject() as Account;
        }

        public async Task<Account> GeAccount(long number)
        {
            return await _dbContext.Set<Account>()
                        .Include(x => x.Client)
                       .Include(x => x.AccountType)
                       .Include(x => x.Transactions)
                        .ThenInclude(x => x.TransactionType)
                        .AsNoTracking().Where(x => x.AccountNumber == number).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GeAccounts()
        {
            return await _dbContext.Set<Account>()
                       .Include(x => x.Client)
                       .Include(x => x.AccountType)
                       .Include(x => x.Transactions)
                        .ThenInclude(x => x.TransactionType)
                       .AsNoTracking().ToListAsync();
        }

        public async Task<List<Account>> GeAccountsByClientId(int clientId)
        {
            return await _dbContext.Set<Account>()
                       .Include(x => x.Client)
                       .Include(x => x.AccountType)
                       .Include(x => x.Transactions)
                        .ThenInclude(x => x.TransactionType)
                       .AsNoTracking().Where(x=> x.ClientId == clientId).ToListAsync();

        }

        public async Task<AccountType> GeAccountType(string code)
        {
            return await _dbContext.Set<AccountType>()
                        .AsNoTracking().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
