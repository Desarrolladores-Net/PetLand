using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ModelObject.Token;
using Domain.Services.Token;
using Microsoft.IdentityModel.Tokens;

namespace Services.Token
{
    public class TokenManager : ITokenManager
    {
        public string GenerateJwt(GenerateJwtMO model)
        {
            var encodig = Encoding.ASCII.GetBytes(model.SecretKey);

            var key = new SymmetricSecurityKey(encodig);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "petland.com",
                audience: "petland.com",
                claims: model.Claims,
                expires: DateTime.UtcNow.AddYears(10),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}