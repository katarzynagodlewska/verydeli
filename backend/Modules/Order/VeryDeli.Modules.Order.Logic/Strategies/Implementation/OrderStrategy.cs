using System;
using System.Threading.Tasks;
using VeryDeli.Modules.Order.Logic.Models;

namespace VeryDeli.Modules.Order.Logic.Strategies.Implementation
{
    internal class OrderStrategy : IOrderStrategy
    {
        public Task<Guid> Process(OrderModel orderModel, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
