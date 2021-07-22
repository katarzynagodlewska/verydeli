using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Libraries.Abstraction.Modules;

namespace VeryDeli.Modules.Food.Api
{
    internal class FoodModule : IModule
    {
        public string Name => "Food";

        public string Path => "Food-Module";

        public void Register(IServiceCollection services)
        {
     //       var domainAssembliesTypes = AppDomain.CurrentDomain.GetAssemblies()
     //.SelectMany(t => t.GetTypes());

     //       var repositoryTypesList = domainAssembliesTypes
     //            .Where(t => t.IsClass && t.Namespace == "MailingList.Data.Repository.Implementation").ToArray();

     //       services.Scan(scan => scan
     //            .FromAssembliesOf(repositoryTypesList)
     //            .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
     //            .AsImplementedInterfaces()
     //            .WithTransientLifetime());

     //       services.AddTransient<IdentityValidator>();

     //       var serviceTypesList = domainAssembliesTypes
     //           .Where(t => t.IsClass && t.Namespace == "MailingList.Logic.Services.Implementation").ToArray();

     //       services.Scan(scan => scan
     //           .FromAssembliesOf(serviceTypesList)
     //           .AddClasses(classes => classes.AssignableTo(typeof(IService)))
     //           .AsImplementedInterfaces()
     //           .WithTransientLifetime());

     //       var commandHandlerAndQueryHandlerTypes = domainAssembliesTypes
     //           .Where(t => t.IsClass && t.Namespace != null &&
     //           (t.Namespace.StartsWith("MailingList.Logic.CommandHandlers") || t.Namespace.StartsWith("MailingList.Logic.QueryHandlers")))
     //           .ToArray();

          //  services.AddMediatR(commandHandlerAndQueryHandlerTypes);
        }

        public void Use(IApplicationBuilder app)
        {
         
        }
    }
}
