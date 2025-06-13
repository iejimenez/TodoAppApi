using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public TodoTaskController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetAll()
        {
            var todos = await _todoTaskService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTaskDto>> GetById(Guid id)
        {
            try
            {
                var todo = await _todoTaskService.GetByIdAsync(id);
                return Ok(todo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoTaskDto>> Create(CreateTodoTaskDto createTodoTaskDto)
        {
            var todo = await _todoTaskService.CreateAsync(createTodoTaskDto);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

    }
}
