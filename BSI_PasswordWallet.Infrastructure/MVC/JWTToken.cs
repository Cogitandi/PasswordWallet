using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.MVC
{
    public static class JWTToken
    {
        public static void UseTokenAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });
        }
        public static string GenerateJSONWebToken(string login, bool showDecryptedPasswords = false)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PasswordWalletSecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("login", login));
            claims.Add(new Claim("showDecrypted", showDecryptedPasswords.ToString()));


            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
