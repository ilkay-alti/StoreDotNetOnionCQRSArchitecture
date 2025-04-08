using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreOnionArchitecture.Infrastructure.Tokens;

namespace StoreOnionArchitecture.Infrastructure
{
    public static class Registration
    {
        public static void  AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(options => configuration.GetSection("JWT"));

        }


    }
}
