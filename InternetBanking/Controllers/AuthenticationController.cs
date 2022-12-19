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
    public class AuthenticationController : ControllerBase
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Task<List<UserResponseDto>> Get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("register-user")]
        public Task<UserResponseDto> registerUser([FromBody] CreateUserDto create)
        {
            return _service.Create(create);
        }

        [HttpPost]
        [Route("login")]
        public Task<UserResponseDto> login([FromBody] LoginDto login)
        {
            return _service.Login(login);
        }
    }
}
