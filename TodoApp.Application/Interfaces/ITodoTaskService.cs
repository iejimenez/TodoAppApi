using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoTaskService
    {
        Task<TodoTaskDto> GetByIdAsync(Guid id);
        Task<IEnumerable<TodoTaskDto>> GetAllAsync();
        Task<TodoTaskDto> CreateAsync(CreateTodoTaskDto createTodoTaskDto);
        Task<TodoTaskDto> UpdateAsync(Guid id, UpdateTodoTaskDto updateTodoTaskDto);
        Task<TodoTaskDto> ToggleStatusAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
