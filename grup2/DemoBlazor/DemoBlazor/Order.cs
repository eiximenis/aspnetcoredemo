namespace DemoBlazor
{

    public static class OrderBuilder 
    {
        public static Order NewOrder()
        {
            return new Order()
            {
                Name = "Test order " + Guid.NewGuid(),
            }
            .AddLine(new OrderLine() { Price = 12.3m, ProductName = "Product1", Qty = 3 })
            .AddLine(new OrderLine() { Price = 11.3m, ProductName = "Product2", Qty = 12 });
        }
    }

    public class Order
    {
        private readonly List<OrderLine> _lines;
        public string Name { get; set; }
        public IEnumerable<OrderLine> Lines { get => _lines; }

        public decimal TotalPrice { get => Lines.Sum(l=>l.Price*l.Qty); }

        public Order()
        {
            _lines = new List<OrderLine>();
        }

        public Order AddLine(OrderLine line)
        {
            _lines.Add(line);
            return this;
        }
    }

    public class OrderLine
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
