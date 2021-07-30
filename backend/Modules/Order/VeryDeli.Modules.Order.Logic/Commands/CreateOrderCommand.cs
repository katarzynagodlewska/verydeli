using System;
using MediatR;
using VeryDeli.Modules.Order.Logic.Models;

namespace VeryDeli.Modules.Order.Logic.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public OrderModel OrderModel { get; set; }
        public Guid UserId { get; set; }
    }
}
