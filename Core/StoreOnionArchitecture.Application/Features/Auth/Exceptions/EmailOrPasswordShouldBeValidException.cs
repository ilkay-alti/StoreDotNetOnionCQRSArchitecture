using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;

namespace StoreOnionArchitecture.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldBeValidException : BaseException
    {
        public EmailOrPasswordShouldBeValidException() : base("Email or password is not valid.")
        { }
    }
}
