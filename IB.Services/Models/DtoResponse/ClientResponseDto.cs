using IB.Domain.Entities;

namespace IB.Application.Models.DtoResponse
{
    public class ClientResponseDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public ClientResponseDto(Client clientEntity)
        {
            Id = clientEntity.Id;
            Name = clientEntity.Name;
            LastName = clientEntity.LastName;
            IdentityDocument = clientEntity.IdentityDocument;
        }
    }
}
