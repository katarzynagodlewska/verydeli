using System.Threading.Tasks;

namespace VeryDeli.Logic.Services.Abstraction
{
    public interface ISeedService : IService
    {
        public Task Seed();
    }
}
