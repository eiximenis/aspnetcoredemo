using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Commands
{
    public class AddTodoItemCommandHandler : IRequestHandler<AddTodoItemCommand, int>
    {
        private readonly ITodoItemRepository _repo;
        public AddTodoItemCommandHandler(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = request.ItemToAdd;
            todoItem.Id = 0;
            _repo.Add(todoItem);
            return todoItem.Id;
        }
    }
}
