using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Educonnect.Core.Authentication
{
    public static class JwtHelpers
    {

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[]
                    {
                new Claim("Id",userAccounts.userId.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.userName),
                new Claim(ClaimTypes.Email, userAccounts.email),
                new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddMinutes(2).ToString("MMM ddd dd yyyy HH:mm:ss tt") )
                    };
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }
        public static UserTokens GenerateTokenkey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var UserToken = new UserTokens();
                if (model == null) throw new ArgumentException(nameof(model));

                // Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.UtcNow.AddMinutes(2);
                UserToken.validity = expireTime.TimeOfDay;
                UserToken.expiration = expireTime;
                var JWToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.UtcNow).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

                UserToken.token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.userName = model.userName;
                UserToken.userId = model.userId;
                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
