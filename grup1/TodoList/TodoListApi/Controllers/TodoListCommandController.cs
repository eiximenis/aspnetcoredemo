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
        private ITodoItemRepository _repo;
        public TodoListCommandController(IMediator mediator, ITodoItemRepository repo)
        {
            _mediator = mediator;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew (TodoItem item)
        {
            var result = await _mediator.Send(new AddTodoItemCommand(item));
            return CreatedAtAction("GetById", "TodoListQuery", new { id = result }, null);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var item = _repo.GetById(id);
            item.MarkAsDone();
            _repo.UnitOfWork.SaveChanges();
            return Ok();
        }
    }
}
