using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using VeryDeli.Api;
using Xunit;

namespace VeryDeli.Tests.Integration.Controllers.Food
{
    public class SearchTests
    {
        public SearchTests()
        {

        }

        [Fact]
        public async Task BasicEndPointTest()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                    webHost.UseStartup<Startup>();
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();


            // Act
            var response = await client.GetAsync("/api/food/GetFoodsByFoodType");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("", responseString);
        }
    }
}
