using System;
using System.Threading.Tasks;
using VeryDeli.Modules.Order.Logic.Models;

namespace VeryDeli.Modules.Order.Logic.Strategies
{
    public interface IOrderStrategy
    {
        public Task<Guid> Process(OrderModel orderModel, Guid userId);
    }
}
