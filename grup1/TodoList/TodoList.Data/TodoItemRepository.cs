using TodoItems.Database;
using TodoList.Domain;
using System.Linq;

namespace TodoList.Data
{
    class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoListDataContext  _bd;

        public TodoItemRepository(TodoListDataContext db)
        {
            _bd = db;
        }

        public void Add(TodoItem item)
        { 
            _bd.Add(item);
            _bd.SaveChanges();
        }

        public TodoItem GetById(int id)
        {
            return _bd.TodoItems.Single(i => i.Id == id);
        }
    }
}