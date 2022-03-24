using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain
{
    public class TodoItem
    {
         
        public int Id { get; set; }
        [Required()]
        public string Text { get; set; }
        public bool Done { get; set; }

    }
}