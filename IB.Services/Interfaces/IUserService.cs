using IB.Application.Interfaces.Base;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAll();
        Task<UserResponseDto> Create(CreateUserDto createDTO);
        Task<UserResponseDto> Login(LoginDto loginDto);
    }
}
