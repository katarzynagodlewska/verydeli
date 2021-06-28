using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Dispatchers;
using VeryDeli.Logic.Dispatchers.Implementation;
using VeryDeli.Logic.Queries.Handlers.Interfaces;
using VeryDeli.Logic.Services;

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
                .Where(t => t.IsClass && t.Namespace == "VeryDeli.Logic.Services.Implementation").ToList();

            services.Scan(scan => scan
                .FromAssembliesOf(serviceTypesList)
                .AddClasses(classes => classes.AssignableTo(typeof(IService)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            var queryHandlersList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "VeryDeli.Logic.Queries.Handlers").ToList();

            services.Scan(scan => scan
                .FromAssembliesOf(queryHandlersList)
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            var commandHandlersList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "VeryDeli.Logic.Commands.Handlers").ToList();

            services.Scan(scan => scan
                .FromAssembliesOf(commandHandlersList)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            return services;
        }
    }
}
