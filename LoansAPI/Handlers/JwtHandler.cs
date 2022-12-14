using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using LoansAPI.Configuration;
using LoansAPI.Dto.Requests;
using LoansAPI.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoansAPI.Services
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
