using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Models.Data.Order;

namespace VeryDeli.Logic.Data.Strategies.Order.Implementation
{
    public class OrderWithDeliveryStrategy : IOrderStrategy
    {
        public async Task<Guid> Process(OrderModel orderModel, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
