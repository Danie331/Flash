
using Flash.DAL.Contract;
using Flash.DAL.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flash.DAL
{
    public static class DependencyMapper
    {
        public static void RegisterDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserDatastore, UserDatastore>();
            services.AddScoped<ICacheConverter, CacheConverter>();
        }
    }
}
