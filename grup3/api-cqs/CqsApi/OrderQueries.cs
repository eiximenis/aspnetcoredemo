using Cqs.Implementation;
using CqsApi.Dtos;
using CqsApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CqsApi
{
    static class OrderQueries
    {
        public static IEnumerable<OrderDto> GetAll([FromServices] CustomDbContext ctx)
        {
            return ctx.Orders.Select(o => o.ToDto());
        }
    }
}
