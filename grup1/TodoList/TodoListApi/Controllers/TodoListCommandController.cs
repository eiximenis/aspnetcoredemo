using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;
using TodoList.Domain.Commands;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("/todos")]
    public class TodoListCommandController : ControllerBase
    {
        private IMediator _mediator;
        public TodoListCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew (TodoItem item)
        {
            var result = await _mediator.Send(new AddTodoItemCommand(item));
            return CreatedAtAction("GetById", "TodoListQuery", new { id = result }, null);
        }
    }
}
