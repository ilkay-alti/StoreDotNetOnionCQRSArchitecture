using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator() { 
        RuleFor(x=>x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("First name must be at least 2 characters long")
                .MaximumLength(20)
                .WithMessage("First name must be at most 20 characters long");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Last name must be at least 8 characters long")
                .MaximumLength(30)
                .WithMessage("Last name must be at most 30 characters long");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is not valid");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Password and Confirm Password do not match");

        }
    }
}
