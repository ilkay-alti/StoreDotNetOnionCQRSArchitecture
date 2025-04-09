using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Application.Features.Auth.Exceptions;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException(user);
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldBeValid(User? user, bool isPasswordValid)
        {
            if (user is null || !isPasswordValid) throw new EmailOrPasswordShouldBeValidException();
            return Task.CompletedTask;
        }

        public Task UserNotregistered(User? user)
        {
            if (user is null) throw new UserNotregisteredException();
            return Task.CompletedTask;
        }

        public Task RefleshTokenShouldNotBeExpired(DateTime? RefleshTokenExpiryTime)
        {
            if(RefleshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new RefleshTokenShouldNotBeException(RefleshTokenExpiryTime);
            }
             throw new UserNotregisteredException();
            
        }
    }
}
