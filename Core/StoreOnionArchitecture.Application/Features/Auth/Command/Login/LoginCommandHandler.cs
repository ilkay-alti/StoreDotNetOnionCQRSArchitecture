using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Features.Auth.Rules;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.Tokens;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthRules _authRules;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(IConfiguration configuration, ITokenService tokenService, UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _userManager = userManager;
            _authRules = authRules;
       
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)

        {
            User user = await _userManager.FindByEmailAsync(request.Email);
            await _authRules.UserNotregistered(user);
            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            await _authRules.EmailOrPasswordShouldBeValid(user, isPasswordValid);


            IList<string> roles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
            string refreshToken = _tokenService.GenerateRefleshToken();


            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefleshToken = refreshToken;
            user.RefleshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);


            return new LoginCommandResponse()
            {
                AccessToken = _token,
                RefreshToken = refreshToken,
                AccessTokenExpiration = token.ValidTo,
            };
        }

    }
}
