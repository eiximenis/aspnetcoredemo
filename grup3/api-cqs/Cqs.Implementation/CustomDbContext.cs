using Cqs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqs.Implementation
{
    public class CustomDbContext : IUnitOfWork
    {
        public CustomDbContext()
        {
            Orders = new List<Order>();
        }
        public ICollection<Order> Orders { get; }

        public Task SaveChangesAsync() => Task.CompletedTask;
    }
}
