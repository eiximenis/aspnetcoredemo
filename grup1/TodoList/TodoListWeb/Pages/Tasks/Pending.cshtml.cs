using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoItems.Database;
using TodoList.Domain;
using TodoListWeb.Queries;

namespace TodoListWeb.Pages.Tasks
{
    public class PendingModel : PageModel
    {
        private readonly TodoItemsDatabase _db;
        public PendingModel(TodoItemsDatabase db)
        {
            _db = db;
        }

        public IEnumerable<TodoItem> TodoItems { get; set; }
        public void OnGet()
        {
            var query = new TodoItemQueries(_db);
            TodoItems = query.GetPending();
        }
    }
}
