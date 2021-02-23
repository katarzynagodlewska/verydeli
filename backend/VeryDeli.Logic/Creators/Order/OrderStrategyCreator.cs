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
            switch (orderChoice)
            {
                case OrderChoice.Delivery:
                    return new OrderWithDeliveryStrategy();
                case OrderChoice.CustomerPick:
                    return new OrderWithCustomerPickStrategy();
                case OrderChoice.EatInRestaurant:
                    return new OrderWithEatInRestaurantStrategy();
                default:
                    throw new LogicException("Could not found order choice");
            }
        }
    }
}
