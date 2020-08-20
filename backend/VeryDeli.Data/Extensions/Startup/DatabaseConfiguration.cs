using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Data.Domains;

namespace VeryDeli.Data.Extensions.Startup
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VeryDeliDataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ConnectionString")));
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<VeryDeliDataContext>();

            return services;
        }

    }
}
