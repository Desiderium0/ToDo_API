using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using To_Do_API.Context;
using To_Do_API;
using To_Do_API.Models;

namespace To_Do_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(ToDoDbContext dbContext) : ControllerBase
    {
        private readonly ToDoDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            return Ok(await _dbContext.ToDo.ToListAsync());    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var result = await _dbContext.ToDo.FindAsync(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo task)
        {
            if (task is null)
                return BadRequest();

            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Todo task)
        {
            var result = await _dbContext.ToDo.FindAsync(id);
            if(result is null)
                return NotFound();

            result.Title = task.Title;
            result.Description = task.Description;  
            result.IsCompleted = task.IsCompleted;
            result.LastUpdated = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todo>>> Delete(int id)
        {
            var result = await _dbContext.ToDo.FindAsync(id);
            if (result is null)
                return NotFound();

            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
