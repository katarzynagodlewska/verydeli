using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Abstraction.Modules;
using VeryDeli.Libraries.Infrastructure.Extensions;
using VeryDeli.Modules.Users.Core.Extensions;

namespace VeryDeli.Modules.Users.Api
{
    internal class UserModule : IModule
    {
        public string Name => "Users";

        public string Path => "VeryDeli.Modules.Users";

        public void Register(IServiceCollection services)
        {
            services
                .AddInfrastructure()
                .RegisterComponents($"{Path}.Core", $"{Path}.Core");
        }

        public void Use(IApplicationBuilder app)
        {
        }
    }
}
