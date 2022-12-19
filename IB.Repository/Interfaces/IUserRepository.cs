using IB.Domain.Entities;
using IB.Infraestructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Infraestructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User entity);
        Task<List<User>> GetUsers();
        Task<User> GetUser(string user, string pass);
        Task<User> GetUserByClientId(int clientId);
    }
}
