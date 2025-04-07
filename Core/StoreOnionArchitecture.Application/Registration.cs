﻿
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using StoreOnionArchitecture.Application.Exceptions;

namespace StoreOnionArchitecture.Application
{
    public static class Registration
    {

        public static void AddAplication(this IServiceCollection services)
        {
            var essembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionsMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(essembly));
        }
    }
}
