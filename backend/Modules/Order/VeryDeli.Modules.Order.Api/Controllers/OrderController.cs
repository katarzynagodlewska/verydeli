﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Modules.Order.Logic.Commands;
using VeryDeli.Modules.Order.Logic.Models;

namespace VeryDeli.Modules.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderModel orderModel)
        {
            try
            {
                var user = HttpContext.GetUser();
                return Ok(await _mediator.Send(new CreateOrderCommand() { OrderModel = orderModel, UserId = user.Id }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
