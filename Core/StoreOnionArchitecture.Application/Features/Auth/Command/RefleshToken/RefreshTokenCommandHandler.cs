using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Features.Auth.Rules;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.Tokens;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.RefleshToken
{
    internal class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly AuthRules _authRules;
        public RefreshTokenCommandHandler(AuthRules authRules,ITokenService tokenService, UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authRules = authRules;
        }




        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await _userManager.FindByEmailAsync(email);
            IList<string> roles = await _userManager.GetRolesAsync(user);



            await _authRules.RefleshTokenShouldNotBeExpired(user.RefleshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
            string newRefreshToken = _tokenService.GenerateRefleshToken();


            user.RefleshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new RefreshTokenCommandResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };
        }
    }


}
