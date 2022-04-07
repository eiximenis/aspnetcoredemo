using Cqs.Domain;

namespace Cqs.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CustomDbContext _dbContext;
        public OrderRepository(CustomDbContext ctx)
        {
            _dbContext = ctx;
        }

        public Task Add(Order order)
        {
            _dbContext.Orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<Order?> GetById(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            return Task.FromResult(order);
        }
    }
}