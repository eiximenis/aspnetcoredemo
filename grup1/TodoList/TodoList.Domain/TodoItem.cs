using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain
{
    public class TodoItem : BaseEntity
    {
         

        [Required()]
        public string Text { get; set; }
        public bool Done { get; private set; }

        public void MarkAsDone()
        {
            if (!Done)
            {
                Done = true;
                AddEvent(new TodoItemResolvedEvent(Id));
            }
        }

    }
}