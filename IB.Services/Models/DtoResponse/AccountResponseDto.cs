using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Application.Models.DtoResponse
{
    public class AccountResponseDto
    {
        public long AccountNumber { get; set; }
        public int ClientId { get; set; }
        public double Balance { get; set; }
        public ClientResponseDto Client { get; set; }

        public AccountResponseDto(Account entity)
        {
            AccountNumber = entity.AccountNumber;
            ClientId = entity.ClientId;
            Balance = entity.Balance;
            Client = entity.Client != null ? new ClientResponseDto(entity.Client) : null;
        }
    }
}
