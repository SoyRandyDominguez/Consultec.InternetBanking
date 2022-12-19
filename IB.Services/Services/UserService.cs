using IB.Application.Interfaces;
using IB.Application.Models.DtoRequest;
using IB.Application.Models.DtoResponse;
using IB.Domain.Entities;
using IB.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IB.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;
        private readonly IClientRepository _ClientRepository;
        public UserService(IUserRepository baseRepo, IClientRepository clientRepo, IConfiguration config)
        {
            this._repository = baseRepo;
            this._ClientRepository = clientRepo;
            this._config = config;
        }

        public async Task<UserResponseDto> Create(CreateUserDto createDTO)
        {
            var client = await _ClientRepository.Create(createDTO.ToClientEntiy());
            createDTO.ClientId = client.Id;
            var user = await _repository.Create(createDTO.ToUserEntiy());
            UserResponseDto responseDto = new UserResponseDto(user);
            responseDto.TokenJwt = GenerateJWTToken(user);
            return responseDto;
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var clients = await _repository.GetUsers();
            return clients.Select(x => new UserResponseDto(x)).ToList();
        }

        public async Task<UserResponseDto> Login(LoginDto loginDto)
        {
            var user = await _repository.GetUser(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return null;
            }
            UserResponseDto responseDto = new UserResponseDto(user);
            responseDto.TokenJwt = GenerateJWTToken(user);
            return responseDto;
        }

        private string GenerateJWTToken(User userInfo)
        {
            string tokenResult = "";
            try
            {
                string sk = _config.GetSection("Jwt").GetSection("SecretKey").Get<string>();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sk));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("name", userInfo.Client.Name),
                new Claim("lastname", userInfo.Client.LastName),
                new Claim("role" ,"User"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
                var token = new JwtSecurityToken(
                    issuer: _config.GetSection("Jwt").GetSection("Issuer").Get<string>(),
                    audience: _config.GetSection("Jwt").GetSection("Audience").Get<string>(),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e )
            {
                return e.Message;
            }
            return tokenResult;
        }
    }
}
