using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Options;
using VeryDeli.Api.Responses.User;
using VeryDeli.Data.Domains;

namespace VeryDeli.Api.Commands.Handlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;

        public UserCommandHandler(UserManager<User> userManager, JwtOptions jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand loginUserCommand)
        {
            var user = await GetUser(loginUserCommand.Login);

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, loginUserCommand.Password);

            if (!userHasValidPassword)
                throw new Exception("Password does not match login.");

            return GenerateAuthResultForUserAsync(user);
        }

        public async Task<User> GetUser(string login, bool isRequired = true)
        {
            var user = await _userManager.FindByEmailAsync(login);

            if (user != null)
                return user;

            user = await _userManager.FindByNameAsync(login);

            if (user == null && isRequired)
                throw new Exception("User does not exist.");

            return null;
        }

        private LoginResponse GenerateAuthResultForUserAsync(IdentityUser<Guid> user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var expiryDate = DateTime.UtcNow.Add(_jwtOptions.TokenLifetime);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = expiryDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse
            {
                Token = tokenHandler.WriteToken(token),
            };
        }

        public async Task<RegisterResponse> Handle(RegisterUserCommand registerUserCommand)
        {
            var user = await GetUser(registerUserCommand.Login, false);

            if (user != null)
                throw new Exception(
                    $"Cannot register new user. User with login {registerUserCommand.Login} is exist in system");

            var newUser = new User
            {
                Email = registerUserCommand.Login,
                UserName = registerUserCommand.Login
            };

            var createdUser = await _userManager.CreateAsync(newUser, registerUserCommand.Password);

            if (!createdUser.Succeeded)
                throw new Exception(createdUser.Errors.Select(e => e.Description).ToString());

            return new RegisterResponse
            {
                Success = true
            };
        }
    }
}
