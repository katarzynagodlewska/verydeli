﻿using System.Threading.Tasks;
using VeryDeli.Api.Responses.Home;

namespace VeryDeli.Api.Queries.Handlers.Interfaces
{
    public interface IFoodQueryHandler : IQueryHandler
    {
        Task<HomeFoodsResponse> Handle(HomeFoodsQuery homeFoodsQuery);
    }
}
