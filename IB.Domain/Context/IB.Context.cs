﻿using IB.Domain.Entities;
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
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public void UsersSeed()
        {
            User admin = new User();
            admin.ClientId = 0;
            admin.UserName = "admin";
            admin.Password = "admin";
            admin.CreatedByUser = "admin";
            Users.Add(admin);
            User randydmz = new User();
            randydmz.ClientId = 1;
            randydmz.UserName = "randydmz";
            randydmz.Password = "randyrandy";
            randydmz.CreatedByUser = "admin";
            Users.Add(randydmz);

            User ashleycm = new User();
            ashleycm.ClientId = 2;
            ashleycm.UserName = "ashleycm";
            ashleycm.Password = "ashley0621";
            ashleycm.CreatedByUser = "admin";
            Users.Add(ashleycm);

            User andrea = new User();
            andrea.ClientId = 3;
            andrea.UserName = "andrea";
            andrea.Password = "andrea1928";
            andrea.CreatedByUser = "admin";
            Users.Add(andrea);
        }
        public void ClientSeed()
        {
            Client admin = new Client();
            admin.Name = "admin";
            admin.LastName = "admin";
            admin.IdentityDocument = "admin";
            admin.CreatedByUser = "admin";
            Clients.Add(admin);

            Client randydmz = new Client();
            randydmz.Name = "Randy";
            randydmz.LastName = "Dominguez";
            randydmz.IdentityDocument = "40213779180";
            randydmz.CreatedByUser = "admin";
            Clients.Add(randydmz);

            Client ashleycm = new Client();
            ashleycm.Name = "Ashley";
            ashleycm.LastName = "Campusano";
            ashleycm.IdentityDocument = "123456789101";
            ashleycm.CreatedByUser = "admin";
            Clients.Add(ashleycm);

            Client andrea = new Client();
            andrea.Name = "Andrea";
            andrea.LastName = "Calzado";
            andrea.IdentityDocument = "00000000000";
            andrea.CreatedByUser = "admin";
            Clients.Add(andrea);
        }
    }
}
