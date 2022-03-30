using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    public class TodoItemResolvedEvent : DomainEvent
    {
        public int TodoItemId { get; }
        public TodoItemResolvedEvent(int id) : base(nameof(TodoItemResolvedEvent))
        {
            TodoItemId = id;
        }
    }
}
