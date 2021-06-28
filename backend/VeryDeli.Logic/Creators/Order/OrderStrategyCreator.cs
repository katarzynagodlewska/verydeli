using VeryDeli.Data.Data;
using VeryDeli.Logic.Data.Enums;
using VeryDeli.Logic.Data.Strategies.Order;
using VeryDeli.Logic.Data.Strategies.Order.Implementation;
using VeryDeli.Logic.Strategies.Order.Implementation;

namespace VeryDeli.Logic.Creators.Order
{
    public class OrderStrategyCreator : IOrderStrategyCreator
    {
        public IOrderStrategy CreateOrderStrategy(OrderChoice orderChoice)
        {
            return orderChoice switch
            {
                OrderChoice.Delivery => new OrderWithDeliveryStrategy(),
                OrderChoice.CustomerPick => new OrderWithCustomerPickStrategy(),
                OrderChoice.EatInRestaurant => new OrderWithEatInRestaurantStrategy(),
                _ => throw new LogicException("Could not found order choice"),
            };
        }
    }
}
