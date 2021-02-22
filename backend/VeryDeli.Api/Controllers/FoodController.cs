using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeryDeli.Api.Extensions;
using VeryDeli.Logic.Commands.Data.Food;
using VeryDeli.Logic.Dispatchers;
using VeryDeli.Logic.Models.Data.Food;
using VeryDeli.Logic.Queries.Data.Food;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public FoodController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("Foods")]
        public async Task<IActionResult> GetFoods([FromQuery] HomeFoodQuery homeFoodsQuery)
        {
            return Ok(await _queryDispatcher.Execute(homeFoodsQuery));
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchFoodQuery searchFoodQuery)
        {
            try
            {
                return Ok(await _queryDispatcher.Execute(searchFoodQuery));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("FoodsForRestaurant")]
        public async Task<IActionResult> GetFoodListForRestaurant(Guid restaurantId)
        {
            try
            {
                return Ok(await _queryDispatcher.Execute(new SearchRestaurantQuery() { RestaurantId = restaurantId }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _queryDispatcher.Execute(new GetFoodQuery() { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] FoodModel foodModel)
        {
            try
            {
                var restaurantUser = HttpContext.GetRestaurantUser();
                return Ok(await _commandDispatcher.Execute(new CreateFoodCommand() { Restaurant = restaurantUser, CreateFoodModel = foodModel }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] FoodModel foodModel)
        {
            try
            {
                return Ok(await _commandDispatcher.Execute(new UpdateFoodCommand() { Id = id, FoodModel = foodModel }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _commandDispatcher.Execute(new DeleteFoodCommand() { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
