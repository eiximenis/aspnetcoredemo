using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqs.Domain
{
    public interface IOrderRepository
    {
        Task<Order?> GetById(int id);
        Task Add(Order order);
    }
}
