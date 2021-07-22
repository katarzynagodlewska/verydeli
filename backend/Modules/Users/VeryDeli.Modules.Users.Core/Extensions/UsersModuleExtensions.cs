using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Infrastructure.Postgres;
using VeryDeli.Modules.Users.Core.Data;

namespace VeryDeli.Modules.Users.Core.Extensions
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<UserModuleDatabaseContext>();

            return services;
        }

        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            return services;
        }
    }
}
