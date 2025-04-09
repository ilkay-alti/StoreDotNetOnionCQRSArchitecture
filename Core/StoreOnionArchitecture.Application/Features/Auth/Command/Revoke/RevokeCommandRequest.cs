﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandRequest: IRequest<Unit>
    {
        public string Email { get; set; }

    }
}
