using Microsoft.AspNetCore.Mvc;
using TodoItems.Database;
using TodoList.Data;
using TodoList.Domain;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("/todos")]
    public class TodoListQueryController : ControllerBase
    {
        private readonly TodoListDataContext _db;
        public TodoListQueryController(TodoListDataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _db.TodoItems;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public ActionResult<TodoItem> GetById(int id)
        {
            var data = _db.TodoItems.FirstOrDefault(x => x.Id == id);
            return data != null ? Ok(data) : NotFound();
        }

        [HttpGet("{name:alpha}")]
        public TodoItem GetByName(string name)
        {
            return _db.TodoItems.FirstOrDefault(x => x.Text.Contains(name));
        }
    }

}
