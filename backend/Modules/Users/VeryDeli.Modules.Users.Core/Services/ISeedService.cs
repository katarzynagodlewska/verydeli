using System.Threading.Tasks;
using VeryDeli.Libraries.Abstraction.Services;

namespace VeryDeli.Modules.Users.Core.Services
{
    public interface ISeedService : IService
    {
        public Task<bool> SeedUserModuleData();
    }
}
