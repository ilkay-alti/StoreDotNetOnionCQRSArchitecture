using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnionArchitecture.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audience { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public int TokenValidityInMunitues { get; set; }


    }
}
