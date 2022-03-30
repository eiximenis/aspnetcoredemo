using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.Models
{
    public class UserLoginViewModel
    {
        [Required()]
        public string UserName { get; set; }
        [Required()]
        public string Password { get; set; }
    }
}
