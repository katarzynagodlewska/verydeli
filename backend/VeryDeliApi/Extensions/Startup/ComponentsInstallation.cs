using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Extensions.Startup
{
    public static class ComponentsInstallation
    {
        public static IServiceCollection RegisterComponents(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromCallingAssembly().AddClasses().AsMatchingInterface()
                .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
