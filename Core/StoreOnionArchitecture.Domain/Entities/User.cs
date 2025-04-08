using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StoreOnionArchitecture.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefleshToken { get; set; }
        public DateTime? RefleshTokenExpiryTime { get; set; }
    }
}
