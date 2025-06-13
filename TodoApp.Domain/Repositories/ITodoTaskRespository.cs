using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories
{
    public interface ITodoTaskRespository
    {
        Task<TodoTask> GetByIdAsync(Guid id);
        Task<IEnumerable<TodoTask>> GetAllAsync();
        Task AddAsync(TodoTask todo);
        Task UpdateAsync(TodoTask todo);
        Task DeleteAsync(Guid id);
    }
}
