using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using VeryDeli.Tests.Integration.Validators;

namespace VeryDeli.Tests.Integration.Seeders
{
    public class BasicDataSeeder
    {
        private readonly IWebHost _host;
        private readonly ApiRequestValidator _apiRequestValidator;

        public BasicDataSeeder(IWebHost Host, ApiRequestValidator apiRequestValidator)
        {
            _host = Host;
            _apiRequestValidator = apiRequestValidator;
        }

        public async Task Seed()
        {
        }
    }
}
