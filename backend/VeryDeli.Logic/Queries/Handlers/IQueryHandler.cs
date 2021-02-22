using System.Threading.Tasks;
using VeryDeli.Logic.Models;

namespace VeryDeli.Logic.Queries.Handlers.Interfaces
{
    public interface IQueryHandler
    {
        Task<ExecuteResult> Execute(IQuery query);
    }
}
