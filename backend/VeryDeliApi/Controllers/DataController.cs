using System;
using System.Collections.Generic;
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
        private readonly VeryDeliDataContext _dbContext;

        public DataController(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IUserService userService, IUserRepository userRepository, IUserTypeRepository userTypeRepository,
            IRestaurantRepository restaurantRepository, VeryDeliDataContext dbContext)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _userService = userService;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _restaurantRepository = restaurantRepository;
            _dbContext = dbContext;
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
                        await _userService.CreateAsync(new User()
                        {
                            Email = $"{item}@e.com",
                            UserName = $"{item}@e.com",
                            UserTypeId = item
                        }, password);
                    }
                }

                var users = await _userRepository.GetAll().ToListAsync();
                var foodsStoredInDatabase = await _foodRepository.GetAll().ToListAsync();
                var rest = await _userRepository.GetAll().Where(u => u.UserTypeId == UserType.Restaurant)
                    .FirstOrDefaultAsync();
                var restaurantUser = await _userRepository.GetAll().Where(u => u.UserTypeId == UserType.Restaurant)
                    .FirstOrDefaultAsync() as Restaurant;
                var restaurantUsers = _restaurantRepository.GetAll().ToList();

                var restss = _dbContext.Restaurants.ToList();
                if (restaurantUser == null)
                    throw new Exception($"Not found restaurant user");


                foreach (var item in Enum.GetValues(typeof(FoodType)).Cast<FoodType>())
                {
                    if (!foodsStoredInDatabase.Any(f => f.FoodFoodTypes.Select(ff => ff.FoodTypeId).Contains(item)))
                    {
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
                            Quantity = 1
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
