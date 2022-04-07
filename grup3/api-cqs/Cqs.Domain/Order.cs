using System.ComponentModel.DataAnnotations;

namespace Cqs.Domain
{
    public class Order
    {
        private List<OrderLine> _lines;
        public int Id { get; set; }

        public Order()
        {
            _lines =   new List<OrderLine>();
        }

        public IEnumerable<OrderLine> Lines { get => _lines; }
        
        public void AddLine(OrderLine line)
        {
            _lines.Add(line);
        }

        public decimal TotalPrice => _lines.Sum(l => l.Price);

        

    }

    public class OrderLine
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}