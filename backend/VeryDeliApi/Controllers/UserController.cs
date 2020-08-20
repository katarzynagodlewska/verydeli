using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VeryDeli.Api.Controllers
{
    public class UserController : Controller
    {
        //TODO
        [HttpPost("api/user/register")]
        public async Task<IActionResult> Register()
        {

            return Ok();
        }

        [HttpPost("api/user/login")]
        public async Task<IActionResult> Login()
        {

            return Ok();
        }
    }
}
