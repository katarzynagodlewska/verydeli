using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;
using FoodType = VeryDeli.Data.Enums.FoodType;
using UserType = VeryDeli.Data.Enums.UserType;

namespace VeryDeli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public DataController(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IUserService userService, IUserRepository userRepository, IUserTypeRepository userTypeRepository,
            IRestaurantRepository restaurantRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _userService = userService;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("Seed")]
        public async Task<IActionResult> Seed()
        {
            try
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

                var imagesFilePathsInProject = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Images\\");

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

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
