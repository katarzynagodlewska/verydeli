using System;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Helpers.Attributes;


namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
