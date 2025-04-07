
using Microsoft.AspNetCore.Builder;

namespace StoreOnionArchitecture.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
        }

    }
}