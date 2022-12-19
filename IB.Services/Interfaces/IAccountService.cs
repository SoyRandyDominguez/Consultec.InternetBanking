using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IB.Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountResponseDto>> GetAll();
        Task<AccountResponseDto> Create(CreateAccountDto createDTO);
        Task<AccountResponseDto> GetByAccountNumber(long number);
        Task<List<AccountResponseDto>> GetByClientId(int clientId);
        Task<double> GetTotalBalanceByClientId(int clientId);
    }
}
