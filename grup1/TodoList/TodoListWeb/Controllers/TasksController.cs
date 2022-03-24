using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;

namespace TodoListWeb.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITodoItemRepository _repo;
        public TasksController(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult New ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Test(int[] data)
        {
            return Ok();
        }

        [HttpPost]
        [ActionName("New")]
        public IActionResult New(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            _repo.Add(item);
            return RedirectToAction(nameof(Added), new {text = item.Text});
        }

        public IActionResult Added(string text)
        {
            ViewBag.Text = text;
            return View();
        }
     }
}
