using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;
using FoodType = VeryDeli.Data.Enums.FoodType;
using UserType = VeryDeli.Data.Enums.UserType;

namespace VeryDeli.Api.Services
{
    public class SeedService : ISeedService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IWebHostEnvironment _env;

        public SeedService(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IUserService userService, IUserRepository userRepository, IUserTypeRepository userTypeRepository,
            IRestaurantRepository restaurantRepository, IWebHostEnvironment env)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _userService = userService;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _restaurantRepository = restaurantRepository;
            _env = env;
        }

        public async Task Seed()
        {
            var foodTypesStoredInDatabase = await _foodTypeRepository.GetAll().Select(ft => ft.Id).ToListAsync();

            foreach (var item in Enum.GetValues(typeof(FoodType)).Cast<FoodType>())
            {
                if (!foodTypesStoredInDatabase.Contains(item))
                {
                    await _foodTypeRepository.Add(new Data.Domains.FoodType
                    {
                        Id = item
                    });
                }
            }

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
                            user = new Customer()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                        case UserType.Restaurant:
                            user = new Restaurant()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                Name = $"{item}_name"
                            };
                            break;
                        case UserType.Courier:
                            user = new Courier()
                            {
                                Email = $"{item}@e.com",
                                UserName = $"{item}@e.com",
                                UserTypeId = item
                            };
                            break;
                        case UserType.Admin:
                            user = new Admin()
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

            var foodsStoredInDatabase = await _foodRepository.GetAll().Include(f => f.FoodFoodTypes).ToListAsync();
            var restaurantUser = await _restaurantRepository.GetAll().FirstOrDefaultAsync();

            if (restaurantUser == null)
                throw new Exception($"Not found restaurant user");

            var appContentPath = _env.ContentRootPath;
            var pathSeparator = "\\verydeli\\backend\\";
            var relativePathToApp = appContentPath.Split(pathSeparator).FirstOrDefault();

            var imagesFilePathsInProject = Directory.GetFiles($"{relativePathToApp}{pathSeparator}images");

            foreach (var item in Enum.GetValues(typeof(FoodType)).Cast<FoodType>())
            {
                if (!foodsStoredInDatabase.Any(f => f.FoodFoodTypes.Select(ff => ff.FoodTypeId).Contains(item)))
                {
                    Image foodImage = null;
                    var imageFilePath = imagesFilePathsInProject.FirstOrDefault(i => i.EndsWith($"{item}_image.jpg".ToLower()));
                    if (!string.IsNullOrWhiteSpace(imageFilePath))
                    {
                        var fileInfo = new FileInfo(imageFilePath);
                        var data = new byte[fileInfo.Length];

                        await using (var fs = fileInfo.OpenRead())
                            fs.Read(data, 0, data.Length);

                        foodImage = new Image
                        {
                            FileName = fileInfo.Name,
                            Data = data,
                            Length = fileInfo.Length,
                            ContentType = "image/jpeg",
                        };
                    }
                    await _foodRepository.Add(new Food
                    {
                        Description = $"{item} description",
                        FoodFoodTypes = new List<FoodFoodType>()
                            {
                                new FoodFoodType
                                {
                                    FoodTypeId = item
                                }
                            },
                        Restaurant = restaurantUser,
                        Name = $"{item} title",
                        Price = 30,
                        Quantity = 1,
                        Image = foodImage,
                        PreparingTime = 30
                    });
                }
            }
        }
    }
}
