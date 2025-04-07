using Microsoft.Extensions.DependencyInjection;
using StoreOnionArchitecture.Application.Interfaces.AutoMapper;

namespace StoreOnionArchitecture.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,AutoMapper.Mapper >();
        }
    }
}
