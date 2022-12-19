﻿using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using System.Collections.Generic;
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
