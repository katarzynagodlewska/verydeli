using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using VeryDeli.Data.Domains;
using VeryDeli.Logic.Models.Results.User;

namespace VeryDeli.Logic.Services
{
    public interface IUserService : IService
    {
        Task<User> GetUser(string login, bool isRequired = true);
        LoginResult GenerateAuthResultForUserAsync(User user);
        Task<User> GetById(Guid userId);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User newUser, string password);
    }
}
