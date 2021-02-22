using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeryDeli.Logic.Commands;
using VeryDeli.Logic.Dispatchers;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public UserController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            try
            {
                return Ok(await _commandDispatcher.Execute(registerUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            try
            {
                return Ok(await _commandDispatcher.Execute(loginUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
