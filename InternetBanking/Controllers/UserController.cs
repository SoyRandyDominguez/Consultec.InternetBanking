using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetBanking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        public UserController(ILogger<UserController> logger, IUserService service)
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
        public Task<UserResponseDto> Post([FromBody] CreateUserDto create)
        {
            return _service.Create(create);
        }
    }
}
