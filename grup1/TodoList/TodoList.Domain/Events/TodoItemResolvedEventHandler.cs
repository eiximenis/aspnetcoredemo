using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Events
{

    public class TodoItemResolvedEventHandler : INotificationHandler<TodoItemResolvedEvent>
    {
        private readonly ILogger<TodoItemResolvedEventHandler> _logger;
        public TodoItemResolvedEventHandler(ILogger<TodoItemResolvedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(TodoItemResolvedEvent request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Task {request.TodoItemId} marked as done");
        }

    }
}
