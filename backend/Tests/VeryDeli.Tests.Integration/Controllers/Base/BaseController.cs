using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeryDeli.Api;
using VeryDeli.Api.Options;
using VeryDeli.Data;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace VeryDeli.Tests.Integration.Controllers.Base
{
    public class BaseController : IDisposable
    {
        protected HttpClient Client;
        protected IHost Host;

        public BaseController()
        {
            Task.WaitAll(Task.Run(async () =>
            {
                Client = await GetHttpClient();
                await Client.GetAsync("/api/data/Seed");
            }));
        }

        protected async Task<HttpClient> GetHttpClient()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((context, builder) => { builder.AddJsonFile("appsettingstest.json"); })
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                    webHost.UseStartup<Startup>();
                    webHost.ConfigureTestServices(services =>
                    {
                        services.Configure<JwtOptions>(opts => { opts.Secret = "TestSecret"; });
                    });
                });

            // Create and start up the host
            Host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            return Host.GetTestClient();
        }

        public void Dispose()
        {
            var dbContext = Host.Services.GetService<VeryDeliDataContext>();
            dbContext.Database.EnsureDeleted();
            Client.Dispose();
            Host.Dispose();
        }
    }
}
