using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Application.Models.DtoRequest
{
    public class CreateAccountDto
    {
        public int ClientId { get; set; }

        public Account ToEntity()
        {
            return new Account() { 
                ClientId = ClientId,
                Balance = 0
            };
        }
    }
}
