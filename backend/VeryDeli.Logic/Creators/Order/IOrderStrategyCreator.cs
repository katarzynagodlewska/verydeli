using VeryDeli.Logic.Data.Enums;
using VeryDeli.Logic.Data.Strategies.Order;

namespace VeryDeli.Logic.Creators.Order
{
    public interface IOrderStrategyCreator
    {
        IOrderStrategy CreateOrderStrategy(OrderChoice orderChoice);
    }
}
