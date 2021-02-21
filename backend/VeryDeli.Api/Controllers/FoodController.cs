using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Dispatchers;
using VeryDeli.Logic.Queries;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        //private readonly IFoodQueryHandler _foodQueryHandler;
        //private readonly ISearchFoodsQueryHandler _searchFoodsQueryHandler;
        //private readonly IFoodCommandHandler _foodCommandHandler;
        private readonly IQueryDispatcher _queryDispatcher;

        //public FoodController(IFoodQueryHandler foodQueryHandler, ISearchFoodsQueryHandler searchFoodsQueryHandler, IFoodCommandHandler foodCommandHandler)
        //{
        //    _foodQueryHandler = foodQueryHandler;
        //    _searchFoodsQueryHandler = searchFoodsQueryHandler;
        //    _foodCommandHandler = foodCommandHandler;
        //}


        public FoodController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("GetFoods")]
        public async Task<IActionResult> GetFoods([FromQuery] HomeFoodsQuery homeFoodsQuery)
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

        [HttpGet("GetFoodListForRestaurant")]
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetFood(Guid id)
        //{
        //    try
        //    {
        //        return Ok(await _foodQueryHandler.Handle(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPost("Create")]
        //[Authorize]
        //public async Task<IActionResult> CreateFood([FromBody] FoodCommand foodCommand)
        //{
        //    try
        //    {
        //        var restaurantUser = HttpContext.GetRestaurantUser();

        //        return Ok(await _foodCommandHandler.Handle(restaurantUser, foodCommand));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut("{id}")]
        //[Authorize]
        //public async Task<IActionResult> UpdateFood(Guid id, [FromBody] FoodCommand foodCommand)
        //{
        //    try
        //    {
        //        return Ok(await _foodCommandHandler.Handle(id, foodCommand));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpDelete("{id}")]
        //[Authorize]
        //public async Task<IActionResult> DeleteFood(Guid id)
        //{
        //    try
        //    {
        //        return Ok(await _foodCommandHandler.Handle(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
