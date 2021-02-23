using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Data.Strategies.Order;
using VeryDeli.Logic.Models.Data.Order;

namespace VeryDeli.Logic.Strategies.Order.Implementation
{
    public class OrderWithCustomerPickStrategy : IOrderStrategy
    {
        public async Task<Guid> Process(OrderModel orderModel, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
