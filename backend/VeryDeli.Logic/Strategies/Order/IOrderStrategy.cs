using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Models.Data.Order;

namespace VeryDeli.Logic.Data.Strategies.Order
{
    public interface IOrderStrategy
    {
        public Task<Guid> Process(OrderModel orderModel, Guid userId);
    }
}
