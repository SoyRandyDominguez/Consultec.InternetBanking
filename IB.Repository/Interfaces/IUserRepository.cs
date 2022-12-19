using IB.Domain.Entities;
using System.Collections.Generic;
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
