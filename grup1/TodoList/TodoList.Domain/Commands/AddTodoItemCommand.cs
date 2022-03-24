using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Commands
{
    public class AddTodoItemCommand : IRequest<int>
    {
        public TodoItem ItemToAdd { get; }
        public AddTodoItemCommand(TodoItem item)
        {
            ItemToAdd = item;
        }
    }
}
