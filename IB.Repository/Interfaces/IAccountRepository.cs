using IB.Domain.Entities;
using IB.Infraestructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Infraestructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Create(Account entity);
        Task<List<Account>> GeAccounts();
        Task<List<Account>> GeAccountsByClientId(int clientId);
        Task<Account> GeAccount(long number);
        Task<AccountType> GeAccountType(string code);

    }
}
