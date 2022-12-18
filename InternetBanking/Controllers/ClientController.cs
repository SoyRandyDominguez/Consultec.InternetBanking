using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBanking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IClientService _service;

        public ClientController(ILogger<WeatherForecastController> logger, IClientService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Task<List<ClientResponseDto>> Get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public Task<ClientResponseDto> Post([FromBody] CreateClientDto create)
        {
            return _service.Create(create);
        }
    }
}
