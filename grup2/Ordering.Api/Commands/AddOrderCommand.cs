using MediatR;
using Ordering.Domain;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Api.Commands
{
    public class AddOrderCommand : IRequest<int>
    { 
        [Required]
        public string CustomerName { get; set; }
        public List<AddOrderCommandOrderLine> Lines { get; set; }

        public AddOrderCommand()
        {
            Lines = new List<AddOrderCommandOrderLine>();
        }

        public Order GetOrder()
        {
            var order = new Order() { CustomerName = CustomerName };
            foreach (var line in Lines)
            {
                order.AddLine(new OrderLine()
                {
                    ProductName = line.ProductName,
                    Qty = line.Qty
                });
            }

            return order;
        }
    }

    public class AddOrderCommandOrderLine
    {
        [Range(1, 10)]
        public int Qty { get; set; } 
        [Required]
        public string ProductName { get; set; }
    }
}
