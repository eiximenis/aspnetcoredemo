namespace Ordering.Domain
{

    public class Order
    {

        private readonly List<OrderLine> _orderLines;

        public Order()
        {
            CustomerName = "";
            _orderLines = new List<OrderLine>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<OrderLine> Lines { get => _orderLines; }

        public void AddLine(OrderLine line)
        {
            _orderLines.Add(line);
        }
             
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}