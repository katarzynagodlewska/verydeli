using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Modules.Users.Core.Data.Domains;
using VeryDeli.Modules.Users.Core.Repository.Abstraction;
using UserType = VeryDeli.Modules.Users.Core.Data.Enums.UserType;

namespace VeryDeli.Modules.Users.Core.Services.Implementation
{
    internal class SeedService : ISeedService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public SeedService(IUserTypeRepository userTypeRepository, IUserRepository userRepository, IUserService userService)
        {
            _userTypeRepository = userTypeRepository;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<bool> SeedUserModuleData()
        {
            var userTypesStoredInDatabase = await _userTypeRepository.GetAll().Select(ut => ut.Id).ToListAsync();

            foreach (var item in Enum.GetValues(typeof(UserType)).Cast<UserType>())
            {
                if (!userTypesStoredInDatabase.Contains(item))
                {
                    await _userTypeRepository.Add(new Data.Domains.UserType
                    {
                        Id = item
                    });
                }
            }


            var userStoredInDatabase = await _userRepository.GetAll().ToListAsync();
            var password = "Test123!";
            foreach (var item in Enum.GetValues(typeof(UserType)).Cast<UserType>())
            {
                if (userStoredInDatabase.All(u => u.UserTypeId != item))
                {
                    User user = null;
                    switch (item)
                    {
                        case UserType.User:
                            user = new User()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                        case UserType.Customer:
                            user = new User()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                        case UserType.Restaurant:
                            user = new User()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                            };
                            break;
                        case UserType.Courier:
                            user = new User()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                        case UserType.Admin:
                            user = new User()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                    }

                    if (user != null)
                        await _userService.CreateAsync(user, password);
                }
            }

            return true;
        }
    }
}
