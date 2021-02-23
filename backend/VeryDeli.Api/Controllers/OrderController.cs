using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeryDeli.Api.Extensions;
using VeryDeli.Logic.Commands.Data.Order;
using VeryDeli.Logic.Dispatchers;
using VeryDeli.Logic.Models.Data.Order;

namespace VeryDeli.Api.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public OrderController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderModel orderModel)
        {
            try
            {
                var user = HttpContext.GetUser();
                return Ok(await _commandDispatcher.Execute(new CreateOrderCommand() { OrderModel = orderModel, UserId = user.Id }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
