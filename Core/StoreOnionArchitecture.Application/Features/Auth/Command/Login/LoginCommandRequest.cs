using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        [DefaultValue("ilkayalti@hotmail.com")]
        public string Email { get; set; }
        [DefaultValue("asdasdasd")]
        public string Password { get; set; }
    }
}
