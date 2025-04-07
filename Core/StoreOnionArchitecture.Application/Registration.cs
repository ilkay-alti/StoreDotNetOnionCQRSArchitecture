using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StoreOnionArchitecture.Application.Beheviors;
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

            services.AddValidatorsFromAssembly(essembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("en");

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehevior<,>));
             

        }
    }
}
