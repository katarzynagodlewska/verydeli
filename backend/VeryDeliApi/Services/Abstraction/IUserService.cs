using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VeryDeli.Api.Responses.User;
using VeryDeli.Data.Domains;

namespace VeryDeli.Api.Services.Abstraction
{
    public interface IUserService : IService
    {
        Task<User> GetUser(string login, bool isRequired = true);
        LoginResponse GenerateAuthResultForUserAsync(User user);
        Task<User> GetById(Guid userId);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User newUser, string password);
    }
}
