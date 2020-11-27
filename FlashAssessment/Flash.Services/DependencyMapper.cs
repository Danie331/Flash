
using Flash.Services.Contract;
using Flash.Services.Core;
using Flash.Services.Core.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flash.Services
{
    public static class DependencyMapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IExceptionManagementService, ExceptionManagementService>();

            DAL.DependencyMapper.RegisterDAL(services, configuration);
        }
    }
}
