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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _service;

        public AccountController(ILogger<AccountController> logger, IAccountService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = Policies.User)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            IActionResult response = Unauthorized();
            List<AccountResponseDto> accounts = await _service.GetAll();
            if (accounts != null && accounts.Count == 0)
            {
                response = NoContent();
            }

            if (accounts != null && accounts.Count > 0)
            {
                response = Ok(accounts);
            }
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto create)
        {
            IActionResult response = Unauthorized();
            AccountResponseDto account = await _service.Create(create);
            if (account != null)
            {
                response = Ok(account);
            }

            return response;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("get-by-account-number")]
        public async Task<IActionResult> Get(long accountNumber)
        {
            IActionResult response = Unauthorized();
            AccountResponseDto account = await _service.GetByAccountNumber(accountNumber);
            if (account == null)
            {
                response = NoContent();
            }

            if (account != null )
            {
                response = Ok(account);
            }
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-all-by-clientid")]
        public async Task<IActionResult> GetByClientId(int clientId)
        {
            IActionResult response = Unauthorized();
            List<AccountResponseDto> accounts = await _service.GetByClientId(clientId);
            if (accounts != null && accounts.Count == 0)
            {
                response = NoContent();
            }

            if (accounts != null && accounts.Count > 0)
            {
                response = Ok(accounts);
            }
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-total-balance-by-clientid")]
        public async Task<IActionResult> GetTotalBalanceByClientId(int clientId)
        {
            double balance = await _service.GetTotalBalanceByClientId(clientId);
            return Ok(balance);
        }
    }
}
