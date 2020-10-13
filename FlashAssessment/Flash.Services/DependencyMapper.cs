
using Flash.Services.Contract;
using Flash.Services.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flash.Services
{
    public static class DependencyMapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkItemService, WorkItemService>();

            DAL.DependencyMapper.RegisterDAL(services, configuration);
        }
    }
}
