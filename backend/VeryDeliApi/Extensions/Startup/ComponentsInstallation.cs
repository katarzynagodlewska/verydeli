using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Extensions.Startup
{
    public static class ComponentsInstallation
    {
        public static IServiceCollection RegisterComponents(this IServiceCollection services)
        {
            var repositoryTypesList = AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(t => t.GetTypes())
                 .Where(t => t.IsClass && t.Namespace == "VeryDeli.Data.Repositories.Implementation").ToList();

            services.Scan(scan => scan
                    .FromAssembliesOf(repositoryTypesList)
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            var serviceTypesList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "VeryDeli.Api.Services").ToList();

            services.Scan(scan => scan
                .FromAssembliesOf(serviceTypesList)
                .AddClasses(classes => classes.AssignableTo(typeof(IService)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(scan => scan.FromCallingAssembly().AddClasses().AsMatchingInterface()
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
