namespace Ordering.Domain
{


    public class Entity
    {
        private List<DomainEvent> _events;
        public int Id { get; set; }

        public Entity()
        {
            _events = new List<DomainEvent>();
        }

        public void AddEvent(DomainEvent evt) => _events.Add(evt);
        public void ClearEvents() => _events.Clear();

        public IEnumerable<DomainEvent> Events => _events;

    }

    public class Order : Entity
    {

        private readonly List<OrderLine> _orderLines;

        public Order()
        {
            CustomerName = "";
            _orderLines = new List<OrderLine>();
        }

        
        public string CustomerName { get; set; }
        public IEnumerable<OrderLine> Lines { get => _orderLines; }

        public void AddLine(OrderLine line)
        {
            _orderLines.Add(line);
        }
             
    }

    public class OrderLine : Entity
    {
        public int Qty { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}