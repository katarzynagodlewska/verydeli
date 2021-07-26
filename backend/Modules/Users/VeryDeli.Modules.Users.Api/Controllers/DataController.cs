using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Modules.Users.Core.Services;

namespace VeryDeli.Modules.Users.Api.Controllers
{
    public class DataController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public DataController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        //TODO should be deleted later
        [HttpGet("Seed")]
        public async Task<IActionResult> Seed()
        {
            try
            {
                await _seedService.SeedUserModuleData();

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
