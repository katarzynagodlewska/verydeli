using System.Linq;
using System.Threading.Tasks;

namespace VeryDeli.Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveById(object id);
        Task<T> GetById(object id);
    }
}
