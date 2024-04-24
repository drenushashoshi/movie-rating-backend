using Microsoft.IdentityModel.Tokens;
using movie_rating_backend.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace movie_rating_backend.Helpers
{
    
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(User user)
        {
            var role = user.Role == Role.User ? "user" : "admin";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddHours(1).ToString())

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
