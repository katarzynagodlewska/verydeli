using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VeryDeli.Data;

namespace VeryDeli.Tests.Integration.TestInfrastructure
{
    public class TestHost : WebApplicationFactory<Api.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove database registrations
                // https://github.com/dotnet/aspnetcore/issues/13918#issuecomment-532162945
                CleanupDatabaseRegistrations<VeryDeliDataContext>(services);

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<VeryDeliDataContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTests");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // BuildDetails the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var appDb = scopedServices.GetRequiredService<VeryDeliDataContext>();

                var logger = scopedServices.GetRequiredService<ILogger<TestHost>>();

                // Ensure the database is created.
                appDb.Database.EnsureCreated();

                try
                {
                    // Seed the database with some specific test data.
                    //_seedDataProvider?.PopulateTestData(appDb);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                }
            });
        }

        private void CleanupDatabaseRegistrations<TDbContext>(IServiceCollection services) where TDbContext : DbContext
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TDbContext));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}
