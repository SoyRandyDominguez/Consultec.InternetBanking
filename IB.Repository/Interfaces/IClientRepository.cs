using IB.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IB.Infraestructure.Interfaces
{
    public interface IClientRepository 
    {
        Task<Client> Create(Client entity);
        Task<List<Client>> GetClients();
    }
}
