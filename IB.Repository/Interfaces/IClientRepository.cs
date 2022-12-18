using IB.Domain.Entities;
using IB.Infraestructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Infraestructure.Interfaces
{
    public interface IClientRepository 
    {
        Task<Client> Create(Client entity);
        Task<List<Client>> GetClients();
    }
}
