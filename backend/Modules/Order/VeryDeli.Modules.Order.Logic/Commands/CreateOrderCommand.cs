using System;
using MediatR;

namespace VeryDeli.Modules.Order.Logic.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}
