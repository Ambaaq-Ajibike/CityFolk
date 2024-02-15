using EventManagementSystem.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EventManagementSystem.AuthService.IJWTAuthService;

namespace EventManagementSystem.AuthService
{
    public class JWTAuthService : IJWTAuthService
    {
        public string _key;
        public JWTAuthService(string key)
        {
            _key = key;
        }
        public string GenerateToken(User model) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            foreach (var userRole in model.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            var tokenDesriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDesriptor);
            return tokenHandler.WriteToken(token);
        }
}
}
