using System.Threading.Tasks;
using VeryDeli.Logic.Commands.Data.Order;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Creators.Order;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Data.Order;
using VeryDeli.Logic.Models.Results.Order;

namespace VeryDeli.Logic.Commands.Handlers.Order
{
    class CreateOrderCommandHandler : ICommandHandler
    {
        private readonly IOrderStrategyCreator _orderStrategyCreator;

        public CreateOrderCommandHandler(IOrderStrategyCreator orderStrategyCreator)
        {
            _orderStrategyCreator = orderStrategyCreator;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var createOrderCommand = command as CreateOrderCommand;

            var orderStrategy = _orderStrategyCreator.CreateOrderStrategy(createOrderCommand.OrderModel.OrderChoice);

            var orderId = await orderStrategy.Process(createOrderCommand.OrderModel, createOrderCommand.UserId);

            return new CreateOrderResult() { OrderId = orderId };
        }
    }
}
