using IB.Domain.Entities;
namespace IB.Application.Models.DtoRequest
{
    public class CreateAccountDto
    {
        public int ClientId { get; set; }
        public string TypeCode { get; set; }
        public string Password { get; set; }

        public Account ToEntity()
        {
            return new Account() { 
                ClientId = ClientId,
                Balance = 0
            };
        }
    }
}
