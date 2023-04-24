using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OpinionAPI.Authorization
{
    public class Auth
    {
        public string GenerateJwtToken(string email, string userId)
        {
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, userId),
              new Claim(JwtRegisteredClaimNames.Email, email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("G-KaNdRgUkXp2s5v"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(7);

            var token = new JwtSecurityToken(
                issuer: "OpinionAPI",
                audience: "OpinionAPI",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
