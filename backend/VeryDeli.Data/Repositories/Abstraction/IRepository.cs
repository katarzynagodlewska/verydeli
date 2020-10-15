using System.Linq;
using System.Threading.Tasks;

namespace VeryDeli.Data.Repositories.Abstraction
{
    public interface IRepository<T, TK> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveById(TK id);
        Task<T> GetById(TK id);
    }
}
