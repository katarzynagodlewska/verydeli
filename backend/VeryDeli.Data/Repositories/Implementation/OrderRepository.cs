using System;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class OrderRepository : CrudRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
