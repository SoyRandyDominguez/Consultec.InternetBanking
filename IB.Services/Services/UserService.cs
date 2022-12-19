using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Application.Services.Base;
using IB.Domain.Entities;
using IB.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IClientRepository _ClientRepository;
        public UserService(IUserRepository baseRepo, IClientRepository clientRepo)
        {
            this._repository = baseRepo;
            this._ClientRepository = clientRepo;
        }

        public async Task<UserResponseDto> Create(CreateUserDto createDTO)
        {
            var client = await _ClientRepository.Create(createDTO.ToClientEntiy());
            createDTO.ClientId = client.Id;
            var user = new UserResponseDto(await _repository.Create(createDTO.ToUserEntiy()));

            return user;
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var clients = await _repository.GetUsers();
            return clients.Select(x => new UserResponseDto(x)).ToList();
        }

        public async Task<UserResponseDto> Login(LoginDto loginDto)
        {
            var client = await _repository.GetUser(loginDto.Username,loginDto.Password);
            if (client == null)
            {
                return null;
            }
            return new UserResponseDto(client);
        }
    }
}
