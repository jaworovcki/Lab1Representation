using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yavandriilab1.Data;

namespace yavandriilab1.Controllers
{
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly LabDataContext _context;

        public TasksController(LabDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Json(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] Data.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}