using IB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Context
{
    public class IBContext : DbContext
    {

        public IBContext(DbContextOptions options) : base(options)
        {
            ClientSeed();
            UsersSeed();
            AccountTypeSeed();
            AccountSeed();
            this.SaveChangesAsync();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public async void UsersSeed()
        {
            var users = await Set<User>().ToListAsync();
            if (users.Count == 0)
            {
                User admin = new User();
                admin.ClientId = 1;
                admin.UserName = "admin";
                admin.Password = "admin";
                admin.CreatedByUser = "admin";
                Set<User>().Add(admin);
                User randydmz = new User();
                randydmz.ClientId = 2;
                randydmz.UserName = "randydmz";
                randydmz.Password = "randyrandy";
                randydmz.CreatedByUser = "admin";
                Users.Add(randydmz);
                Set<User>().Add(randydmz);

                User ashleycm = new User();
                ashleycm.ClientId = 3;
                ashleycm.UserName = "ashleycm";
                ashleycm.Password = "ashley0621";
                ashleycm.CreatedByUser = "admin";
                Users.Add(ashleycm);
                Set<User>().Add(ashleycm);

                User andrea = new User();
                andrea.ClientId = 4;
                andrea.UserName = "andrea";
                andrea.Password = "andrea1928";
                andrea.CreatedByUser = "admin";
                Users.Add(andrea);
                Set<User>().Add(andrea);
            }
        }
        public async void ClientSeed()
        {
            var clients = await Set<Client>().ToListAsync();
            if (clients.Count == 0)
            {
                Client admin = new Client();
                admin.Name = "admin";
                admin.LastName = "admin";
                admin.IdentityDocument = "admin";
                admin.CreatedByUser = "admin";
                Set<Client>().Add(admin);

                Client randydmz = new Client();
                randydmz.Name = "Randy";
                randydmz.LastName = "Dominguez";
                randydmz.IdentityDocument = "40213779180";
                randydmz.CreatedByUser = "admin";
                Set<Client>().Add(randydmz);

                Client ashleycm = new Client();
                ashleycm.Name = "Ashley";
                ashleycm.LastName = "Campusano";
                ashleycm.IdentityDocument = "123456789101";
                ashleycm.CreatedByUser = "admin";
                Set<Client>().Add(ashleycm);

                Client andrea = new Client();
                andrea.Name = "Andrea";
                andrea.LastName = "Calzado";
                andrea.IdentityDocument = "00000000000";
                andrea.CreatedByUser = "admin";
                Set<Client>().Add(andrea);

            }


            
        }
        public async void AccountSeed()
        {
            var accounts = await Set<Account>().ToListAsync();
            if(accounts.Count == 0)
            {
                Account account = new Account();
                account.Balance = 100;
                account.AccountTypeId = 1;
                account.AccountNumber = 1234567890;
                account.ClientId = 1;
                Set<Account>().Add(account);
            }
        }

        public async void AccountTypeSeed()
        {
            var types = await Set<AccountType>().ToListAsync();
            if (types.Count == 0)
            {
                AccountType savings = new AccountType();
                savings.Name = "Savings ";
                savings.Code = "SA";
                Set<AccountType>().Add(savings);

                AccountType checking = new AccountType();
                checking.Name = "Checking";
                checking.Code = "CA";
                Set<AccountType>().Add(checking);
            }
        }


    }
}
