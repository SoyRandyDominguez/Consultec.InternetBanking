﻿using IB.Application.Interfaces.Base;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IB.Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientResponseDto>> GetAll();
        Task<ClientResponseDto> Create(CreateClientDto createDTO);
    }
}