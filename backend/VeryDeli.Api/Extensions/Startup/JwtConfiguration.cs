using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Logic.Options;

namespace VeryDeli.Api.Extensions.Startup
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.Bind(nameof(jwtOptions), jwtOptions);
            services.AddSingleton(jwtOptions);

            return services;
        }
    }
}
