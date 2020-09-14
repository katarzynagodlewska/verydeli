using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Queries.Handlers;
using VeryDeli.Api.Queries.Handlers.Interfaces;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodQueryHandler _foodQueryHandler;

        public FoodController(IFoodQueryHandler foodQueryHandler)
        {
            _foodQueryHandler = foodQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoodsByFoodType([FromQuery] HomeFoodsQuery homeFoodsQuery)
        {
            return Ok(await _foodQueryHandler.Handle(homeFoodsQuery));
        }
    }
}
