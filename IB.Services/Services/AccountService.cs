using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Domain.Entities;
using IB.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IConfiguration _config;
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        public AccountService(IAccountRepository baseRepo, IClientRepository clientRepo, IUserRepository userRepo, IConfiguration config)
        {
            this._repository = baseRepo;
            this._clientRepository = clientRepo;
            this._userRepository = userRepo;
            this._config = config;
        }

        public async Task<AccountResponseDto> Create(CreateAccountDto createDTO)
        {
            User user = await _userRepository.GetUserByClientId(createDTO.ClientId);
            if (user == null|| !user.Password.Equals(createDTO.Password))
            {
                return null;
            }
            Account entity = createDTO.ToEntity();
            entity.AccountNumber = await GenerateAccountNumber();
            AccountType accountType = await _repository.GeAccountType(createDTO.TypeCode);
            if (accountType != null)
            {
                entity.AccountTypeId = accountType.Id;
            }

            var account = await _repository.Create(entity);
            AccountResponseDto responseDto = new AccountResponseDto(account);
            return responseDto;
        }

        public async Task<List<AccountResponseDto>> GetAll()
        {
            var clients = await _repository.GeAccounts();
            return clients.Select(x => new AccountResponseDto(x)).ToList();
        }

        public async Task<AccountResponseDto> GetByAccountNumber(long number)
        {
            var account = await _repository.GeAccount(number);
            return new AccountResponseDto(account);
        }

        public async Task<List<AccountResponseDto>> GetByClientId(int clientId)
        {
            var clients = await _repository.GeAccountsByClientId(clientId);
            return clients.Select(x => new AccountResponseDto(x)).ToList();
        }

        public async Task<double> GetTotalBalanceByClientId(int clientId)
        {
            var clients = await _repository.GeAccountsByClientId(clientId);
            return clients.Sum(x=> x.Balance);
        }

        private async Task<long> GenerateAccountNumber()
        {
            bool canCreate = false;
            var random = new Random();
            string s = string.Empty;
            while (canCreate == false)
            {
                for (int i = 0; i < 10; i++)
                    s = String.Concat(s, random.Next(10).ToString());
                var account = await _repository.GeAccount(long.Parse(s));
                if (account == null)
                {
                    canCreate = true;
                }
            }
            return long.Parse(s);
        }

    }
}
