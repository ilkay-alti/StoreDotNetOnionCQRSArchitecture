using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace StoreOnionArchitecture.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest:IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
    }
}
