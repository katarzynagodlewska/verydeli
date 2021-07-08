using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Abstraction.Options;

namespace VeryDeli.Api.Infrastructure.Extensions
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
