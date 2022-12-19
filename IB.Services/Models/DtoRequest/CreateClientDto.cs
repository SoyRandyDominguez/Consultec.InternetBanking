using IB.Domain.Entities;
namespace IB.Application.Models.DtoRequest
{
    public class CreateClientDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public Client ToEntiy()
        {
            return new Client()
            {
                Name = Name,
                LastName = LastName,
                IdentityDocument = IdentityDocument
            };
        }
    }
}
