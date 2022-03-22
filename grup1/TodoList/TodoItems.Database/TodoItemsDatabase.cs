using TodoList.Domain;

namespace TodoItems.Database
{
    public class TodoItemsDatabase
    {
        private List<TodoItem> _todoItems;
        public IEnumerable<TodoItem> TodoItems { get => _todoItems; }

        public void Add(TodoItem item) => _todoItems.Add(item);

        public TodoItemsDatabase()
        {
            _todoItems = new List<TodoItem>();
            _todoItems.Add(new TodoItem()
            {
                Id = 1,
                Done = false,
                Text = "Planxar la roba"
            });

            _todoItems.Add(new TodoItem()
            {
                Id = 2,
                Done = false,
                Text = "Regar les plantes"
            });
        }
    }
}