using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Queries;
using VeryDeli.Api.Queries.Handlers;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Data;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodQueryHandler _foodQueryHandler;
        private readonly ISearchFoodsQueryHandler _searchFoodsQueryHandler;
        private readonly VeryDeliDataContext _context;
        private readonly IRestaurantRepository _restaurantRepository;

        public FoodController(IFoodQueryHandler foodQueryHandler, ISearchFoodsQueryHandler searchFoodsQueryHandler, VeryDeliDataContext context, IRestaurantRepository restaurantRepository)
        {
            _foodQueryHandler = foodQueryHandler;
            _searchFoodsQueryHandler = searchFoodsQueryHandler;
            _context = context;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("GetFoodsByFoodType")]
        public async Task<IActionResult> GetFoodsByFoodType([FromQuery] HomeFoodsQuery homeFoodsQuery)
        {
            var cos = _restaurantRepository.GetAll().ToList();
            var cos2 = _context.Restaurants.ToList();
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
