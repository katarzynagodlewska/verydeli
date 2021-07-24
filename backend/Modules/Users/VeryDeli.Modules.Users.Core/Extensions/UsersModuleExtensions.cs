using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Infrastructure.Postgres;
using VeryDeli.Modules.Users.Core.Data;
using VeryDeli.Modules.Users.Core.Data.Domains;

namespace VeryDeli.Modules.Users.Core.Extensions
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgres<UserModuleDatabaseContext>();

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<UserModuleDatabaseContext>();

            return services;
        }
    }
}
