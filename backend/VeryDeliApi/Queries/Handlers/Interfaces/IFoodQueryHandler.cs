using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeryDeli.Api.Responses.Food;
using VeryDeli.Api.Responses.Home;

namespace VeryDeli.Api.Queries.Handlers.Interfaces
{
    public interface IFoodQueryHandler : IQueryHandler
    {
        Task<HomeFoodsResponse> Handle(HomeFoodsQuery homeFoodsQuery);
        Task<FoodDetailsResponse> Handle(Guid id);
        Task<List<FoodListItemResponse>> Handle(SearchRestaurantQuery searchRestaurantQuery);
    }
}
