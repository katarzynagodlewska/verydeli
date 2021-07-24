﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VeryDeli.Libraries.Abstraction.Services;
using VeryDeli.Modules.Users.Core.Data.Domains;
using VeryDeli.Modules.Users.Core.Responses;

namespace VeryDeli.Modules.Users.Core.Services
{
    internal interface IUserService : IService
    {
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User newUser, string password);
        LoginResponse GenerateAuthResultForUserAsync(User user);
        Task<User> GetById(Guid userId);
        Task<User> GetUser(string login, bool isRequired = true);
    }
}