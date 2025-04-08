using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Features.Products.Exceptions;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(string requestTitle, IList<Product> products)
        {
            if (products.Any(x=> x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException(requestTitle);
            return Task.CompletedTask;
        }
    }
}
