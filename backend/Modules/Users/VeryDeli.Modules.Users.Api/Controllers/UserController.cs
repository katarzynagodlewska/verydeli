using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Modules.Users.Core.Commands;

namespace VeryDeli.Modules.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] IRequest<RegisterUserCommand> registerUserCommand)
        {
            try
            {
                return Ok(await _mediator.Send(registerUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] IRequest<LoginUserCommand> loginUserCommand)
        {
            try
            {
                return Ok(await _mediator.Send(loginUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
