using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Service
{
    public class TokenService
    {
        private const string SecretKey = "D8a%6Pz#bQ9x^1vZ3rR4k@tF6vU5eJ7!nM8jH3wD2zQ9bC7uA5eR9gT4wJ1lX8haaaa"; // Khóa bí mật
        public string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId), // Claim định danh người dùng
            }),
                Expires = DateTime.UtcNow.AddHours(1), // Token có hiệu lực trong 1 giờ
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature) // Sử dụng HS512 để ký
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Trả về chuỗi token
        }
    }
}