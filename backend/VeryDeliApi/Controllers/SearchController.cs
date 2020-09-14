using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Queries;
using VeryDeli.Api.Queries.Handlers.Interfaces;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISearchFoodsQueryHandler _searchFoodsQueryHandler;

        public SearchController(ISearchFoodsQueryHandler searchFoodsQueryHandler)
        {
            _searchFoodsQueryHandler = searchFoodsQueryHandler;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromBody] SearchFoodQuery searchFoodQuery)
        {
            try
            {
                return Ok(await _searchFoodsQueryHandler.Handle(loginUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
