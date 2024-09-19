using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using System.Linq;
using Task = ToDoApp.Models.Task;
using System.Diagnostics;

namespace ToDoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(string taskName)
        {
            if (!string.IsNullOrEmpty(taskName))
            {
                _context.Tasks.Add(new Task { TaskName = taskName });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleTask(int id)
        {

            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.State = !task.State;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
