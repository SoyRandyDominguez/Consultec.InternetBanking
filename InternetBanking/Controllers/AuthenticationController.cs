using IB.Api.Base.JWTAuthentication.JWTAuthenticationExample.Models;
using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = Policies.User)]
        public Task<List<UserResponseDto>> Get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register-user")]
        public Task<UserResponseDto> registerUser([FromBody] CreateUserDto create)
        {
            return _service.Create(create);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            IActionResult response = Unauthorized();

            UserResponseDto user = await _service.Login(login);
            if (user != null)
            {
                response = Ok(user);
            }

            return response;
        }
    }
}
