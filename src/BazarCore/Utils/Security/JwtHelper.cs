using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BazarCore.Utils.Security
{
    public static class JwtHelper
    {
        private const string SecretKey = "580c49df-4110-4ebe-9d90-447fe5c79ca4";
        private static readonly byte[] SecretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);

        public static string GenerateJwtToken(string userId, string username, int expirationInMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(SecretKeyBytes);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddMinutes(expirationInMinutes),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool TryReadJwtToken(string jwtToken, out JwtSecurityToken? securityToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
                securityToken = (JwtSecurityToken)validatedToken;
                return true;
            }
            catch
            {
                securityToken = null;
                return false;
            }
        }
    }
}
