using Cqs.Domain;
using CqsApi.Dtos;

namespace CqsApi.Extensions
{
    static class OrderExtensions
    {
        public static Order ToEntity (this OrderInputDto dto)
        {
            var order = new Order ();  
            foreach (var line in dto.Lines)
            {
                order.AddLine(new OrderLine()
                {
                    Description = line.Description,
                    Price = line.Price,
                });
            }

            return order;
        }

        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Total = order.TotalPrice,
                Lines = order.Lines.Select(l => new OrderLineDto()
                {
                    Description = l.Description,
                    Price = l.Price,
                }).ToList()
            };
        }
    }
}
