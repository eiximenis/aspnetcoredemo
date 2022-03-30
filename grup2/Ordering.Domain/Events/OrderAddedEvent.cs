using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Events
{
    public class OrderAddedEvent : DomainEvent, INotification
    {
        public Order Order { get; }

        public OrderAddedEvent(Order order)
        {
            Order = order;
        }
    }
}
