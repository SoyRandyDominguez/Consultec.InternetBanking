using IB.Domain.Entities;


namespace IB.Application.Models.DtoResponse
{
    public class AccountTypeResponseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public AccountTypeResponseDto(AccountType entity)
        {
            Name = entity.Name;
            Code = entity.Code;
        }
    }
}
