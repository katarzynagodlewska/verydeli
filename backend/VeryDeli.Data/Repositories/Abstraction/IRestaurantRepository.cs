using System;
using VeryDeli.Data.Domains;

namespace VeryDeli.Data.Repositories.Abstraction
{
    public interface IRestaurantRepository : IRepository<Restaurant, Guid>
    {
    }
}
