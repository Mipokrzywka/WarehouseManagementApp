using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _duration;

        public TokenService(IConfiguration config)
        {
            var jwtKey = config["Jwt:Key"] ?? throw new ArgumentNullException("JWT Key is missing in app settings");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            _issuer = config["Jwt:Issuer"] ?? "WarehouseManagementBackend";
            _audience = config["Jwt:Audience"] ?? "WarehouseManagementFrontend";

            if (!int.TryParse(config["Jwt:DurationInMinutes"], out _duration))
            {
                _duration = 120;
            }
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("Surname", user.Surname)
            };
            if (user.UserRoles != null) {
                foreach (var userRole in user.UserRoles)
                {
                    if (userRole.Role != null) 
                    {
                        foreach (var rolePermission in userRole.Role.RolePermissions)
                        {
                            if (rolePermission.Permission != null) 
                            {
                                claims.Add(new Claim("Permission", rolePermission.Permission.Name));
                            }
                        }
                    }
                    
                }
            }

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_duration),
                SigningCredentials = credentials,
                Issuer = _issuer,
                Audience = _audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);
        }
    }
}
