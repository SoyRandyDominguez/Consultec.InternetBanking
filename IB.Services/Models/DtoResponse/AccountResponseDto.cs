using IB.Domain.Entities;


namespace IB.Application.Models.DtoResponse
{
    public class AccountResponseDto
    {
        public long AccountNumber { get; set; }
        public int ClientId { get; set; }
        public int? TypeId { get; set; }
        public double Balance { get; set; }
        public ClientResponseDto Client { get; set; }
        public AccountTypeResponseDto AccountType { get; set; }
        public AccountResponseDto(Account entity)
        {
            AccountNumber = entity.AccountNumber;
            ClientId = entity.ClientId;
            Balance = entity.Balance;
            TypeId = entity.AccountTypeId;
            AccountType = entity.AccountType != null ? new AccountTypeResponseDto(entity.AccountType) : null;
            Client = entity.Client != null ? new ClientResponseDto(entity.Client) : null;
        }
    }
}
