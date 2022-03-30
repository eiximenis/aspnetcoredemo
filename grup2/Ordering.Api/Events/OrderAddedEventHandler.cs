using MediatR;
using Ordering.Domain.Events;

namespace Ordering.Api.Events
{
    public class OrderAddedEventHandler : INotificationHandler<OrderAddedEvent>
    {
        private readonly ILogger _logger;
        public OrderAddedEventHandler(ILogger<OrderAddedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(OrderAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"+++++ ORDER ADDED: {notification.When} + {notification.Order.Id}");
            return Task.CompletedTask;
        }
    }
}
