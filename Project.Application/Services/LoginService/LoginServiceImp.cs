using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Common.Helper.PasswordHandle;
using Project.Application.Dtos.LoginDtos;
using Project.Application.Interfaces.LoginInterface;
using Project.Core.Context;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.LoginService
{
    public class LoginServiceImp : ILogin
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly float _jwtTimeOut = 30;
        public LoginServiceImp(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<JwtResponseDto> Login(LoginRequest request)
        {
            var verifyAccount = await VerifyAccount(request.Email, request.Password);
            if (verifyAccount)
            {
                var result = GetJwtToken(request.Email);
                return result;
            }
            return JwtResponseDto.Faild();
        }
        private JwtResponseDto GetJwtToken(string email)
        {
            var tokenPrefix = "Bearer";
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtTimeOut),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"]
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var result = tokenPrefix + " " + jwtTokenHandler.WriteToken(token);
            return new JwtResponseDto
            {
                IsSuccess = true,
                Token = result
            };
        }

        private async Task<bool> VerifyAccount(string email, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
            if (account != null)
            {
                var IsCorrectPassword = PasswordHandle.ComparePassword(account.Password, password);
                if (IsCorrectPassword)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
