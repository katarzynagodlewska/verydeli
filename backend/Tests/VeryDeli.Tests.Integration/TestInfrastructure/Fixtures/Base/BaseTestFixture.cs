using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeryDeli.Api.Options;

namespace VeryDeli.Tests.Integration.TestInfrastructure.Fixtures.Base
{
    public class BaseTestFixture : IDisposable
    {
        private readonly TestServer _server;

            public HttpClient Client { get; }

            public BaseTestFixture()
            {
            //var hostBuilder = new HostBuilder()
            //    .ConfigureAppConfiguration((context, builder) =>
            //    {
            //        builder.AddJsonFile("appsettingstest.json");
            //    })
            //    .ConfigureWebHost(webHost =>
            //    {
            //        // Add TestServer
            //        webHost.UseTestServer();
            //        webHost.UseEnvironment("Test");
            //        webHost.UseStartup<Api.Startup>();
            //        webHost.ConfigureTestServices(services =>
            //        {
            //            services.Configure<JwtOptions>(opts =>
            //            {
            //                opts.Secret = "TestSecret";
            //            });
            //        });
            //    });

            var builder = new WebHostBuilder()
              .UseStartup<Api.Startup>()
              .ConfigureAppConfiguration((context, config) =>
              {
                  config.SetBasePath(Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "..\\..\\..\\..\\AspNetCoreTodo"));

                  config.AddJsonFile("appsettingstest.json");
              });

            _server = new TestServer(builder);

                Client = _server.CreateClient();
                Client.BaseAddress = new Uri("http://localhost:8888");
            }

            public void Dispose()
            {
                Client.Dispose();
                _server.Dispose();
            }
        }
    }
}
