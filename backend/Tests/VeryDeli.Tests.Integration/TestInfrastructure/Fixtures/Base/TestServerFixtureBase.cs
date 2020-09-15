//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.DependencyInjection;
//using VeryDeli.Tests.Integration.TestInfrastructure.Startup;

//namespace VeryDeli.Tests.Integration.TestInfrastructure.Fixtures.Base
//{
//    public abstract class TestServerFixtureBase<T> : IDisposable where T : TestServerStartup
//    {
//        public readonly TestServer Server;
//        private readonly SettingsHelper _settingsHelper =
//            new SettingsHelper(HostingEnvironmentNameProvider.Test);
//        protected TestServerFixtureBase()
//        {
//            CleanupDatabase();

//            Server = new TestServer(
//                new WebHostBuilder()
//                    .UseEnvironment("Integration Test")
//                    .UseStartup<T>());

//            ((TestMessageHandlerProvider)Server.Host.Services.GetService<IDefaultMessageHandlerProvider>()).TestServer = Server;
//            Tenant = Server.Host.Services.GetService<IDefaultTenantReader>().GetAll().First();

//            InitDatabase();
//        }

//        private HttpClient CreateClient()
//        {
//            return Server.CreateClient();
//        }

//        public async Task<HttpClient> CreateAuthorizedClientApiAdmin()
//        {
//            var adminUser = _settingsHelper.GetInitialUserOptions().Value.Users.First(u => u.RoleName == "Administrator");
//            return await CreateAuthorizedClientApi(adminUser.Email, Encoding.UTF8.GetString(Convert.FromBase64String(adminUser.Password)));
//        }

//        private async Task<HttpClient> CreateAuthorizedClientApi(string email, string password)
//        {
//            var client = CreateClient();
//            var identityServerSettings = _settingsHelper.GetIdentityServerOptions();

//            var result =
//                await client.GetAsync(
//                    $"/api/v1/account/" +
//                    $"?email={email}" +
//                    $"&password={password}" +
//                    $"&apiSecret={identityServerSettings.Value.MobileClientSecret}");

//            //  var token = await result.Content.ReadAsAsync<ApiResultModel<dynamic>>();
//            var token = "";
//            var authorizedClient = CreateClient();
//      //      authorizedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", parameter: token.ResponseData.token.ToString());

//            return authorizedClient;
//        }


//        private void ApplyMigrations()
//        {
//            this.RunSync(async () => await Server.CreateClient().GetAsync("/data/migrate"));
//        }

//        private void CleanupDatabase()
//        {
//            if (!TestDatabaseSnapshotManager.HasSnapshot())
//            {
//                TestDatabaseSnapshotManager.InitFolderAndCleanup(_settingsHelper.GetTenants().First().DatabaseSettings.ConnectionString);
//            }
//        }

//        private void InitDatabase()
//        {
//            if (!TestDatabaseSnapshotManager.HasSnapshot())
//            {
//                ApplyMigrations();
//                TestDatabaseSnapshotManager.CreateSnapshot(_settingsHelper.GetTenants().First().DatabaseSettings.ConnectionString);
//            }
//            else
//            {
//                TestDatabaseSnapshotManager.RestoreFromSnapshot(_settingsHelper.GetTenants().First().DatabaseSettings.ConnectionString);
//            }
//        }

//        public void Dispose()
//        {
//            Server?.Dispose();
//        }
//    }
//}
