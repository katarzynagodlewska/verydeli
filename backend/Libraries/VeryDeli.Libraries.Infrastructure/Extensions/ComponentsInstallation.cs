using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VeryDeli.Libraries.Abstraction.Repository;
using VeryDeli.Libraries.Abstraction.Services;

namespace VeryDeli.Libraries.Infrastructure.Extensions
{
    public static class ComponentsInstallation
    {
        public static IServiceCollection RegisterComponents(this IServiceCollection services, string logicModulePath, string dataModulePath)
        {
            var domainAssembliesTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .ToList();

            var repositoryTypesList = domainAssembliesTypes
                 .Where(t => t.IsClass && t.Namespace == $"{dataModulePath}.Repository.Implementation").ToArray();

            services.Scan(scan => scan
                 .FromAssembliesOf(repositoryTypesList)
                 .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
                 .AsImplementedInterfaces()
                 .WithTransientLifetime());

            var serviceTypesList = domainAssembliesTypes
                .Where(t => t.IsClass && t.Namespace == $"{logicModulePath}.Services.Implementation").ToArray();

            services.Scan(scan => scan
                .FromAssembliesOf(serviceTypesList)
                .AddClasses(classes => classes.AssignableTo(typeof(IService)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            var commandHandlerAndQueryHandlerTypes = domainAssembliesTypes
                .Where(t => t.IsClass && t.Namespace != null &&
                (t.Namespace.StartsWith($"{logicModulePath}.CommandHandlers") || t.Namespace.StartsWith($"{logicModulePath}.QueryHandlers")))
                .ToArray();

            services.AddMediatR(commandHandlerAndQueryHandlerTypes);

            return services;
        }
    }
}
