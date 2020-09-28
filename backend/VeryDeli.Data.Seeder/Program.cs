using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeryDeli.Api.Services;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Implementation;
using FoodType = VeryDeli.Data.Enums.FoodType;
using UserType = VeryDeli.Data.Enums.UserType;

namespace VeryDeli.Data.Seeder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Seed data");
            Console.WriteLine("Other: Quit");

            var choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)
            {
                var seederResult = await SeedData();

                Console.WriteLine($"Seeder result {seederResult}");
            }

            Console.WriteLine("End");
        }

        private static async Task<bool> SeedData()
        {
            try
            {
                await using var dbContext = SetUpDbConnection();

                await Seed(dbContext);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        private static VeryDeliDataContext SetUpDbConnection()
        {
            const string connectionString =
                "Server=(localdb)\\mssqllocaldb;Database=VeryDeli-App11;Trusted_Connection=True;MultipleActiveResultSets=true";

            var optionsBuilder = new DbContextOptionsBuilder<VeryDeliDataContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContext = new VeryDeliDataContext(optionsBuilder.Options);

            return dbContext;
        }

        private static async Task Seed(VeryDeliDataContext dbContext)
        {
            var foodRepository = new FoodRepository(dbContext);
            var foodTypeRepository = new FoodTypeRepository(dbContext);
            var userTypeRepository = new UserTypeRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            var restaurantRepository = new RestaurantRepository(dbContext);
            //var userService = new UserService();
            var serviceCollection = new ServiceCollection();

            var userService = serviceCollection.BuildServiceProvider().GetService<IUserService>();

            var foodTypesStoredInDatabase = await foodTypeRepository.GetAll().Select(ft => ft.Id).ToListAsync();

            foreach (var item in Enum.GetValues(typeof(FoodType)).Cast<FoodType>())
            {
                if (!foodTypesStoredInDatabase.Contains(item))
                {
                    await foodTypeRepository.Add(new Data.Domains.FoodType
                    {
                        Id = item
                    });
                }
            }

            var userTypesStoredInDatabase = await userTypeRepository.GetAll().Select(ut => ut.Id).ToListAsync();

            foreach (var item in Enum.GetValues(typeof(UserType)).Cast<UserType>())
            {
                if (!userTypesStoredInDatabase.Contains(item))
                {
                    await userTypeRepository.Add(new Data.Domains.UserType
                    {
                        Id = item
                    });
                }
            }


            var userStoredInDatabase = await userRepository.GetAll().ToListAsync();
            var password = "Test123!";
            foreach (var item in Enum.GetValues(typeof(UserType)).Cast<UserType>())
            {
                if (userStoredInDatabase.All(u => u.UserTypeId != item))
                {
                    await userService.CreateAsync(new User()
                    {
                        Email = $"{item}@e.com",
                        UserName = $"{item}@e.com",
                        UserTypeId = item
                    }, password);
                }
            }

            var foodsStoredInDatabase = await foodRepository.GetAll().ToListAsync();
            var restaurantUser = await restaurantRepository.GetAll().FirstOrDefaultAsync();

            if (restaurantUser == null)
                throw new Exception($"Not found restaurant user");

            foreach (var item in Enum.GetValues(typeof(FoodType)).Cast<FoodType>())
            {
                if (!foodsStoredInDatabase.Any(f => f.FoodFoodTypes.Select(ff => ff.FoodTypeId).Contains(item)))
                {
                    await foodRepository.Add(new Food
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

        }
    }
}
