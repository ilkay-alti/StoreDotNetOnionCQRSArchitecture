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

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Revoke
{
    internal class RevokeCommandHandler: BaseHandler,IRequestHandler<RevokeCommandRequest, Unit>
    {

        private readonly UserManager<User> _userManager;
        private readonly AuthRules _authRules;

        public RevokeCommandHandler(UserManager<User> userManager,AuthRules authRules, IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _userManager = userManager;
            _authRules = authRules;
        }


        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
           User user = await _userManager.FindByEmailAsync(request.Email);

            await _authRules.EmailAdressShouldBeValid(user);

            user.RefleshToken = null;
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }

}
