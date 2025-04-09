using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException(User? user) : base($"User with email {user?.Email} already exist.")
        {
        }
        
    }

}



