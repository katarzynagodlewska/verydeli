using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VeryDeli.Api.Controllers;
using VeryDeli.Logic.Models.Results.Food;
using VeryDeli.Logic.Queries.Data.Food;
using VeryDeli.Tests.Integration.Api.Controllers.Base;
using Xunit;

namespace VeryDeli.Tests.Integration.Api.Controllers
{
    [Collection("Db")]
    public class FoodControllerTests : BaseController
    {
        private const int _maxRowsForRequest = 12;

        [Fact]
        public async Task GetFoodsByFoodType_GivenBreakfastType_ShouldReturnFoodListRelatedToBreakfast()
        {
            var foodController = Host.Services.GetService<FoodController>();

            var resposne = await foodController.GetFoods(new HomeFoodQuery()
            {
                FoodType = Data.Enums.FoodType.Breakfast
            });

            ApiRequestValidator.EnsureRequestSuccess<OkObjectResult>(resposne);

            var homeFoodResposne = (HomeFoodsResult)((OkObjectResult)resposne).Value;

            Assert.All(homeFoodResposne.FoodModels, foodModel => Assert.Contains(Data.Enums.FoodType.Breakfast, foodModel.FoodTypes));
            Assert.True(homeFoodResposne.FoodModels.Count <= _maxRowsForRequest);
        }

        [Fact]
        public async Task GetFoodsByFoodType_GivenDinnerType_ShouldReturnFoodListRelatedToDinner()
        {
            var foodController = Host.Services.GetService<FoodController>();

            var resposne = await foodController.GetFoods(new HomeFoodQuery()
            {
                FoodType = Data.Enums.FoodType.Dinner
            });

            ApiRequestValidator.EnsureRequestSuccess<OkObjectResult>(resposne);

            var homeFoodResposne = (HomeFoodsResult)((OkObjectResult)resposne).Value;

            Assert.All(homeFoodResposne.FoodModels, foodModel => Assert.Contains(Data.Enums.FoodType.Dinner, foodModel.FoodTypes));
            Assert.True(homeFoodResposne.FoodModels.Count <= _maxRowsForRequest);
        }

        [Fact]
        public async Task GetFoodsByFoodType_GivenLunchType_ShouldReturnFoodListRelatedToLunch()
        {
            var foodController = Host.Services.GetService<FoodController>();

            var resposne = await foodController.GetFoods(new HomeFoodQuery()
            {
                FoodType = Data.Enums.FoodType.Lunch
            });

            ApiRequestValidator.EnsureRequestSuccess<OkObjectResult>(resposne);

            var homeFoodResposne = (HomeFoodsResult)((OkObjectResult)resposne).Value;

            Assert.All(homeFoodResposne.FoodModels, foodModel => Assert.Contains(Data.Enums.FoodType.Lunch, foodModel.FoodTypes));
            Assert.True(homeFoodResposne.FoodModels.Count <= _maxRowsForRequest);
        }
    }
}
