﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace StoreOnionArchitecture.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
}
