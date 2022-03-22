using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoListWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Name { get; set; }
        public string Title { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Title = "Developer";
            Name = "Edu";
        }

        public void OnGet()
        {

        }


    }
}