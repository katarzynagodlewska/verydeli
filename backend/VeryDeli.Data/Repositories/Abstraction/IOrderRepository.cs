using System;
using VeryDeli.Data.Domains;

namespace VeryDeli.Data.Repositories.Abstraction
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
