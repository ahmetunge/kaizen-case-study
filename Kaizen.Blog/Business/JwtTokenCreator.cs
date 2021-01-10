using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.Utilities.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kaizen.Blog.Business
{
    public class JwtTokenCreator : ITokenCreator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenCreator(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
       
        public string CreateToken(Claim[] claims)
        {
            JwtSecurityTokenHandler tokenHandler= new ();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(SecurityKeyHelper.CreateSecurity(_jwtSettings.SecretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
