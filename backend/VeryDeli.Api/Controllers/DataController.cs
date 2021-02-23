using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Services;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public DataController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        //TODO probably should be deleted later
        //
        [HttpGet("Seed")]
        public async Task<IActionResult> Seed()
        {
            try
            {
                await _seedService.Seed();

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
