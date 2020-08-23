using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using VeryDeli.Api.Options;
using VeryDeli.Api.Responses.User;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager, JwtOptions jwtOptions, IUserRepository userRepository)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _userRepository = userRepository;
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

        public LoginResponse GenerateAuthResultForUserAsync(User user)
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

        public async Task<User> GetById(Guid userId)
        {
            return await _userRepository.GetById(userId);
        }

        public Task<bool> CheckPasswordAsync(User user, string password) => _userManager.CheckPasswordAsync(user, password);


        public Task<IdentityResult> CreateAsync(User newUser, string password) =>
            _userManager.CreateAsync(newUser, password);
    }
}
