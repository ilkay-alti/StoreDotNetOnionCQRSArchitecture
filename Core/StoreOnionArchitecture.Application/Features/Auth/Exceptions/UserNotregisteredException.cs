using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;

namespace StoreOnionArchitecture.Application.Features.Auth.Exceptions
{
    public class UserNotregisteredException : BaseException
    {
        public UserNotregisteredException() : base("User not registered.")
        { }
    }
}
