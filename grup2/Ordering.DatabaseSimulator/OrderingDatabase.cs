using Ordering.Domain;

namespace Ordering.DatabaseSimulator
{
    public class OrderingDatabase
    {
        private readonly List<Order> _orders;

        public OrderingDatabase()
        {
            _orders = new List<Order>();
        }

        public int AddOrUpdateOrder(Order order)
        {
            if (order.Id == 0)
            {
                order.Id = _orders.Count() + 1;
                _orders.Add(order);
                return order.Id;
            }
            else
            {
                if (_orders.Any(o => o.Id == order.Id))
                {
                    var orderToDelete = _orders.FirstOrDefault(o => o.Id == order.Id);
                    _orders.Remove(orderToDelete);
                    _orders.Add(order);
                    return order.Id;
                }
                else
                {
                    throw new InvalidOperationException($"Not found order with id: {order.Id}");
                }
            }
        }

        public Order? GetOrderById(int id) 
            => _orders.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Order> GetAllOrders() => _orders;
    }
}