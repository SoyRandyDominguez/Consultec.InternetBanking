using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Application.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _repository;
        public ClientService(IClientRepository baseRepo)
        {
            this._repository = baseRepo;
        }
        public async Task<ClientResponseDto> Create(CreateClientDto createDTO)
        {
            var client = new ClientResponseDto(await _repository.Create(createDTO.ToEntiy()));
            return client;
        }
        public async Task<List<ClientResponseDto>> GetAll()
        {
            var clients = await _repository.GetClients();
            return clients.Select(x => new ClientResponseDto(x)).ToList();
        }
    }
}
