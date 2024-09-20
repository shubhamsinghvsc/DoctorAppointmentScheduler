using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Users user)
        {
            // Get security key from configuration
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Create signing credentials using HMAC SHA256 algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define the claims for the token
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim("Email", user.Email),
        new Claim("ContactNumber", user.ContactNumber),
    };

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials);

            // Write and return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
