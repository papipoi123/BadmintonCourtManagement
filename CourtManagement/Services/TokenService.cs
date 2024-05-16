using Applications;
using Applications.Commons;
using Applications.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIs.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppConfiguration _appConfiguration;
        public TokenService(AppConfiguration appconfig)
        {
            _appConfiguration = appconfig;
        }
        public Task<string> GetToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim("userID",user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.email),
                new Claim(ClaimTypes.Role, user.role.ToString())
            };
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.JWTSecretKey));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(40),
                signingCredentials: credentials
                );
            var tokenreal = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(tokenreal);
        }
    }
}
