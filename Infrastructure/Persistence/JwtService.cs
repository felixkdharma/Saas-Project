using Application.Interfaces;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class JwtService : IJWTService
    {
        private readonly string _secretKey = "THIS_IS_SUPER_DUPER_SECRET_KEY_123456";
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("userId", user.CUSER_ID.ToString()),
                new Claim(ClaimTypes.Email, user.CEMAIL.ToString()),
                new Claim(ClaimTypes.Role, user.CUSER_ROLE.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
