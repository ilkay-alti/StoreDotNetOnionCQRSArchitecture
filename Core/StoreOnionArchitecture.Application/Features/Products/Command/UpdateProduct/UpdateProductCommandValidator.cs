using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StoreOnionArchitecture.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Descripion");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Brand");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Price");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Categorys");

        }
    }
}
