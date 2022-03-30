using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain
{
    public interface IOrdersRepository
    {
        Task<Order?> GetById(int id);
        Task<bool> DeleteOrder(int id);

        Task AddOrder(Order order);
    }
}
