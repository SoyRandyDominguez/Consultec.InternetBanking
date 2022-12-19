using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Application.Models.DtoRequest
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
