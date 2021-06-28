using System;

namespace VeryDeli.Logic.Models.Results.Order
{
    public class CreateOrderResult : ExecuteResult
    {
        public Guid OrderId { get; set; }
    }
}
