using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VeryDeli.Api.Controllers;
using VeryDeli.Api.Queries.Handlers;
using VeryDeli.Api.Responses.Home;
using VeryDeli.Tests.Integration.Api.Controllers.Base;
using Xunit;

namespace VeryDeli.Tests.Integration.Api.Controllers.Food
{
    [Collection("Db")]
    public class FoodControllerTests : BaseController
    {
        [Fact]
        public async Task GetFoodsByFoodType_GivenBreakfastType_ShouldReturnFoodListRelatedToBreakfast()
        {
            //arranhe
            var foodController = Host.Services.GetService<FoodController>();

            //act
            var resposne = await foodController.GetFoodsByFoodType(new HomeFoodsQuery()
            {
                FoodType = Data.Enums.FoodType.Breakfast
            });

            // Assert

            ApiRequestValidator.EnsureRequestSuccess<OkObjectResult>(resposne);

            var homeFoodResposne = (HomeFoodsResponse)((OkObjectResult)resposne).Value;

            Assert.All(homeFoodResposne.FoodModels, foodModel => Assert.Equal(foodModel.)

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("", responseString);
        }

        [Fact]
        public async Task Seach_S_ShouldBeTrue()
        {

            //arrange

            //act
            var response = await Client.GetAsync("/api/food/GetFoodsByFoodType");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("", responseString);
        }
    }
}
