using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVC.Configuration;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtOptions jwtOptions;

        public JwtHandler(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }
        
        public string GenerateToken(AuthRequest user, Role rol)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user, rol);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }

        public SigningCredentials GetSigningCredentials()
        {
            //Esto debe ser configurable por ambiente. Secret Manager podria ser una solucion https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }

        public List<Claim> GetClaims(AuthRequest user, Role rol)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, rol.ToString())
            };
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
