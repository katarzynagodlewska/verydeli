using Microsoft.AspNetCore.Http;
using VeryDeli.Data.Domains;

namespace VeryDeli.Api.Extensions
{
    public static class HttpContextExtension
    {
        public static User GetUser(this HttpContext httpContext)
        {
            var user = httpContext.Items["User"] as User;

            return user;
        }

        public static Restaurant GetRestaurantUser(this HttpContext httpContext)
        {
            var user = httpContext.Items["User"] as Restaurant;

            return user;
        }
    }
}
