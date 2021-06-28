using System;
using VeryDeli.Logic.Models.Data.Order;

namespace VeryDeli.Logic.Commands.Data.Order
{
    public class CreateOrderCommand : ICommand
    {
        public OrderModel OrderModel { get; set; }
        public Guid UserId { get; set; }
    }
}
