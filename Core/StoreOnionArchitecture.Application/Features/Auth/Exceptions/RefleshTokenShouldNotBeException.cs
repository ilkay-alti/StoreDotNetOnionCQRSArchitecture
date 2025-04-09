using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOnionArchitecture.Application.Bases;
using StoreOnionArchitecture.Domain.Entities;

namespace StoreOnionArchitecture.Application.Features.Auth.Exceptions
{
    public class RefleshTokenShouldNotBeException:BaseException
    {

    
        
            public RefleshTokenShouldNotBeException(DateTime? RefleshTokenExpiryTime) : base($"Reflesh token should not be expired. Expiry date: {RefleshTokenExpiryTime}")
        { }

        
    }
}
