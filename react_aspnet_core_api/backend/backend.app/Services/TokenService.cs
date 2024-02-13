using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.app.Interfaces.Services;
using backend.domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace backend.app.Services
{
    public class TokenService : ITokenService
    {
        readonly string _tokenKey;
        public TokenService(string tokenKey)
        {
            _tokenKey = tokenKey;
        }
        public string CreateTokenAsync(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (user.UserRoles != null)
            {
                foreach (var role in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role!.Role!.Name));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}