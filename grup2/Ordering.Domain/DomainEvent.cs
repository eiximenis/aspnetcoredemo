using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain
{
    public class DomainEvent
    {
        public Guid Id { get; }
        public DateTime When { get; }
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            When = DateTime.UtcNow;
        }
    }
}
