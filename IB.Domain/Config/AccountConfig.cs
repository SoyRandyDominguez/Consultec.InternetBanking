using IB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Domain.Config
{
    internal class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(x => x.AccountType).WithMany()
            .HasForeignKey(x => x.AccountTypeId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
