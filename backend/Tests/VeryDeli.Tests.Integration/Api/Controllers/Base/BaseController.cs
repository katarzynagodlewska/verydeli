﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using VeryDeli.Api;
using VeryDeli.Data;
using VeryDeli.Tests.Integration.Seeders;
using VeryDeli.Tests.Integration.Validators;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace VeryDeli.Tests.Integration.Api.Controllers.Base
{
    public class BaseController : IDisposable
    {
        protected TestServer _server;
        protected IWebHost Host;
        protected ApiRequestValidator ApiRequestValidator;

        public BaseController()
        {
            Task.WaitAll(Task.Run(async () =>
            {
                _server = new TestServer(new WebHostBuilder()
                            .UseEnvironment("Test")
                            .UseStartup<Startup>()
                            .ConfigureTestServices(services =>
                            {
                            })
                            );
                Host = _server.Host;
                ApiRequestValidator = new ApiRequestValidator();
                await SeedCustomData();
            }));
        }

        private async Task SeedCustomData()
        {
            var basicDataSeeder = new BasicDataSeeder(Host, ApiRequestValidator);
            await basicDataSeeder.Seed();
        }

        public void Dispose()
        {
            var dbContext = Host.Services.GetService<VeryDeliDataContext>();
            dbContext.Database.EnsureDeleted();
            Host.Dispose();
        }
    }
}