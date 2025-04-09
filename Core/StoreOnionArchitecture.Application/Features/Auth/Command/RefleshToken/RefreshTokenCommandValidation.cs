using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.RefleshToken
{
    public class RefreshTokenCommandValidation:AbstractValidator<RefreshTokenCommandRequest>
    {

        public RefreshTokenCommandValidation()
        {
            RuleFor(x => x.AccessToken)
                .NotEmpty().WithMessage("Access token is required.")
                .NotNull().WithMessage("Access token cannot be null.");
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required.")
                .NotNull().WithMessage("Refresh token cannot be null.");
        }
    }
}
