using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Features.Auth.Rules;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;
using StoreOnionArchitecture.Application.Interfaces.UnitOfWorks;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>

    {

        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _userManager = userManager;
            _roleManager = roleManager;

        }




        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(request.Email));

            User user = _mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.FullName = request.FirstName + " " + request.LastName;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("user"))
                    await _roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "user".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });

                await _userManager.AddToRoleAsync(user, "user");

            }
            return Unit.Value;
        }
    }

}

