using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreOnionArchitecture.Application.Interfaces;
using StoreOnionArchitecture.Persistence.Context;
using StoreOnionArchitecture.Persistence.Repositories;

namespace StoreOnionArchitecture.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                        )); 

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        }
    }
}
