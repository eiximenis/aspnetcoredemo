using TodoItems.Database;
using TodoList.Domain;

namespace TodoListWeb.Queries
{
    public class TodoItemQueries
    {
        private readonly TodoItemsDatabase _db;

        public TodoItemQueries(TodoItemsDatabase db)
        {
            _db = db;
        }

        public IEnumerable<TodoItem> GetPending() => _db.TodoItems.Where(i => !i.Done);
    }
}
