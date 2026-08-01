using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NexFlow.Application.Common.Authentication;
using NexFlow.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexFlow.Infrastructure.Authentication
{
    public sealed class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        public TokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }
        public JwtToken GenerateTokenAsync(TokenUser user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Name, user.FullName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: _jwtOptions.Issuer,
               audience: _jwtOptions.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes),
               signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(token);

            return new JwtToken(accessToken, token.ValidTo);
        }
    }
}
