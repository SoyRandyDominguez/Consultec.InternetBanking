using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Application.Models.DtoResponse
{
    public class AccountTypeResponseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public AccountTypeResponseDto(AccountType entity)
        {
            Name = entity.Name;
            Code = entity.Code;
        }
    }
}
