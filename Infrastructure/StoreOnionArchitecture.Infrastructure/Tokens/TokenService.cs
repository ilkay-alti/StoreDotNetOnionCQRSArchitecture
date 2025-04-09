using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreOnionArchitecture.Application.Interfaces.Tokens;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _tokenSettings;
        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            _tokenSettings = options.Value ?? throw new ArgumentNullException(nameof(options));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

  
        }


        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {

            

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JwtId
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // Email
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // NameIdentifier
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenSettings.TokenValidityInMunitues),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            await _userManager.AddClaimsAsync(user, claims); //User Claims Database Entry

            return token;
        }

        public string GenerateRefleshToken()
        {

            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);


        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? AccessToken)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret))
            };
            JwtSecurityTokenHandler tokenHandler = new();

            var principal = tokenHandler.ValidateToken(AccessToken, tokenValidationParameters, out SecurityToken securityToken);

            if(securityToken is not JwtSecurityToken jwtSecurityToken 
                || !jwtSecurityToken
                .Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
