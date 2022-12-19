using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Application.Models.DtoResponse
{
    public class UserResponseDto
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public int? ClientId { get; set; }
        public ClientResponseDto Client { get; set; }

        public UserResponseDto(User userEntity)
        {
            Id = userEntity.Id;
            Username = userEntity.UserName;
            ClientId = userEntity.ClientId;
            Client = userEntity.Client != null ? new ClientResponseDto(userEntity.Client) : null;
        }
    }
}
