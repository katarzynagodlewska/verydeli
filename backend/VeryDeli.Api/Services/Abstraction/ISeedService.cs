using System.Threading.Tasks;

namespace VeryDeli.Api.Services.Abstraction
{
    public interface ISeedService : IService
    {
        public Task Seed();
    }
}
