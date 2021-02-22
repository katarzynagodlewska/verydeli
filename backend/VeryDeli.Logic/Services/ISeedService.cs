using System.Threading.Tasks;

namespace VeryDeli.Logic.Services
{
    public interface ISeedService : IService
    {
        public Task Seed();
    }
}
