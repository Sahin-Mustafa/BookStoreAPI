using BookAPI.Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using T = BookAPI.Application.DTOs;

namespace BookAPI.Infrastructure.Service.Token
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public T.Token CreateAccessToken()
        {
            T.Token token = new();


            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SigningKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMonths(6);

            JwtSecurityToken securityToken = new
                (
                    expires: token.Expiration,
                    notBefore: DateTime.UtcNow,
                    signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}