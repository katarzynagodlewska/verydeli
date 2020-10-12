using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Commands;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Extensions;
using VeryDeli.Api.Helpers.Attributes;
using VeryDeli.Api.Queries;
using VeryDeli.Api.Queries.Handlers;
using VeryDeli.Api.Queries.Handlers.Interfaces;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodQueryHandler _foodQueryHandler;
        private readonly ISearchFoodsQueryHandler _searchFoodsQueryHandler;
        private readonly IFoodCommandHandler _foodCommandHandler;

        public FoodController(IFoodQueryHandler foodQueryHandler, ISearchFoodsQueryHandler searchFoodsQueryHandler, IFoodCommandHandler foodCommandHandler)
        {
            _foodQueryHandler = foodQueryHandler;
            _searchFoodsQueryHandler = searchFoodsQueryHandler;
            _foodCommandHandler = foodCommandHandler;
        }

        [HttpGet("GetByFoodType")]
        public async Task<IActionResult> GetFoodsByFoodType([FromQuery] HomeFoodsQuery homeFoodsQuery)
        {
            return Ok(await _foodQueryHandler.Handle(homeFoodsQuery));
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchFoodQuery searchFoodQuery)
        {
            try
            {
                return Ok(await _searchFoodsQueryHandler.Handle(searchFoodQuery));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(Guid id)
        {
            try
            {
                return Ok(await _foodQueryHandler.Handle(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> CreateFood([FromBody] FoodCommand foodCommand)
        {
            try
            {
                var restaurantUser = HttpContext.GetRestaurantUser();

                return Ok(await _foodCommandHandler.Handle(restaurantUser, foodCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(Guid id, [FromBody] FoodCommand foodCommand)
        {
            try
            {
                return Ok(await _foodCommandHandler.Handle(id, foodCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(Guid id)
        {
            try
            {
                return Ok(await _foodCommandHandler.Handle(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
