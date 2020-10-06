using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public FoodController(IFoodQueryHandler foodQueryHandler, ISearchFoodsQueryHandler searchFoodsQueryHandler)
        {
            _foodQueryHandler = foodQueryHandler;
            _searchFoodsQueryHandler = searchFoodsQueryHandler;
        }

        [HttpGet("GetFoodsByFoodType")]
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
    }
}
