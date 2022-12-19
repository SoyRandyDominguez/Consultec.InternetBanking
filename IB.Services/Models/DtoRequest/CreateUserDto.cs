using IB.Domain.Entities;

namespace IB.Application.Models.DtoRequest
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityDocument { get; set; }
        public int? ClientId { get; set; }

        public User ToUserEntiy()
        {
            return new User() { 
                ClientId = ClientId ?? null,
                UserName = Username,
                Password = Password
            };
        }

        public Client ToClientEntiy()
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
