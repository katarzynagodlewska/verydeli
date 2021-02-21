using System.Threading.Tasks;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Queries;

namespace VeryDeli.Logic.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<ExecuteResult> Execute(IQuery query);
    }
}
