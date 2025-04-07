using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace StoreOnionArchitecture.Application
{
    public static class Registration
    {

        public static void AddAplication(this IServiceCollection services)
        {
            var essembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(essembly));
        }
    }
}
