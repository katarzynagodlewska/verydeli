using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Abstraction.Modules;
using VeryDeli.Modules.Users.Core.Extensions;

namespace VeryDeli.Modules.Users.Api
{
    internal class UserModule : IModule
    {
        public string Name => "User";

        public string Path => "User-Module";

        public void Register(IServiceCollection services)
        {
            services
                .AddLogic()
                .AddInfrastructure();
        }

        public void Use(IApplicationBuilder app)
        {
        }
    }
}
