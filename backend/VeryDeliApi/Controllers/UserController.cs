using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeryDeli.Api.Commands;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Queries.Handlers.Interfaces;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserCommandHandler _userCommandHandler;
        private readonly IUserQueryHandler _userQueryHandler;

        public UserController(IUserCommandHandler userCommandHandler, IUserQueryHandler userQueryHandler)
        {
            _userCommandHandler = userCommandHandler;
            _userQueryHandler = userQueryHandler;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            try
            {
                return Ok(await _userCommandHandler.Handle(registerUserCommand));
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
                return Ok(await _userCommandHandler.Handle(loginUserCommand));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
