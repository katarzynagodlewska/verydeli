//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using VeryDeli.Data.Repositories.Abstraction;
//using VeryDeli.Logic.Models;

//namespace VeryDeli.Logic.Queries.Handlers.Food
//{
//    public class FoodQueryHandler : IFoodQueryHandler
//    {
//        private readonly IFoodRepository _foodRepository;

//        public FoodQueryHandler(IFoodRepository foodRepository)
//        {
//            _foodRepository = foodRepository;
//        }


//        public async Task<List<FoodListItemResponse>> Handle(SearchRestaurantQuery searchRestaurantQuery)
//        {
//            return await _foodRepository
//                .GetAll()
//                .Include(f => f.Restaurant)
//                .Where(f => f.Restaurant.Id == searchRestaurantQuery.RestaurantId)
//                .Select(f => new FoodListItemResponse()
//                {
//                    Id = f.Id,
//                    Title = f.Name,
//                    Price = f.Price,
//                    Description = f.Description,
//                    PreparingTime = f.PreparingTime,
//                })
//                .ToListAsync();
//        }
//    }
//}
