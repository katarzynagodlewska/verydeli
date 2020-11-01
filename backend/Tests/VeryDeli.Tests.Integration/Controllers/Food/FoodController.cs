using System.Threading.Tasks;
using VeryDeli.Tests.Integration.Controllers.Base;
using Xunit;

namespace VeryDeli.Tests.Integration.Controllers.Food
{
    [Collection("Db")]
    public class FoodController : BaseController
    {
        [Fact]
        public async Task GetFoodsByFoodType_S_ShouldBeTrue()
        {

            //
            var response = await Client.GetAsync("/api/food/GetFoodsByFoodType");

            // Assert
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
