using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetTasks([FromQuery] bool? isCompleted = null)
        {
            IQueryable<TaskItem> query = _context.Tasks;

            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }

            var tasks = await query.Select(t => new TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                DueDate = t.DueDate,
                Priority = t.Priority.ToString()
            }).ToListAsync();

            return tasks;
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItem(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            var taskItemDto = new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                DueDate = taskItem.DueDate,
                Priority = taskItem.Priority.ToString()
            };

            return taskItemDto;
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            taskItem.Title = updateTaskItemDto.Title;
            taskItem.Description = updateTaskItemDto.Description;
            taskItem.IsCompleted = updateTaskItemDto.IsCompleted;
            taskItem.DueDate = updateTaskItemDto.DueDate;
            
            if (Enum.TryParse<PriorityLevel>(updateTaskItemDto.Priority, out var priority))
            {
                taskItem.Priority = priority;
            }

            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> PostTaskItem(CreateTaskItemDto createTaskItemDto)
        {
            var taskItem = new TaskItem
            {
                Title = createTaskItemDto.Title,
                Description = createTaskItemDto.Description,
                DueDate = createTaskItemDto.DueDate
            };

            if (Enum.TryParse<PriorityLevel>(createTaskItemDto.Priority, out var priority))
            {
                taskItem.Priority = priority;
            }

            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();

            var taskItemDto = new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                DueDate = taskItem.DueDate,
                Priority = taskItem.Priority.ToString()
            };

            return CreatedAtAction("GetTaskItem", new { id = taskItem.Id }, taskItemDto);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskItemExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}