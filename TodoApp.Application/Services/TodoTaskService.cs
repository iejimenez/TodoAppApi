using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        public Task<IEnumerable<TodoTaskDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoTaskDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
