using Microsoft.EntityFrameworkCore;
using Ordering.Domain;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly OrderingContext _ctx;
        public OrdersRepository(OrderingContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await GetById(id);
            if (order is not null)
            {
                _ctx.Orders.Remove(order);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Order?> GetById(int id)
        {
            return await _ctx.Orders
                .Include(o => o.Lines)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOrder(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            order.AddEvent(new OrderAddedEvent(order));
        }
    }
}
