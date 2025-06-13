using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Infrastructure.Data;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApi.Infrastructure.Repositories
{
    public class TodoTaskRepoditory : ITodoTaskRespository
    {
        private readonly ApplicationDbContext _context;

        public TodoTaskRepoditory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoTask> GetByIdAsync(Guid id)
        {
            return await _context.TodoTasks.FindAsync(id);
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        public async Task AddAsync(TodoTask todo)
        {
            await _context.TodoTasks.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoTask todo)
        {
            _context.TodoTasks.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var todo = await _context.TodoTasks.FindAsync(id);
            if (todo != null)
            {
                _context.TodoTasks.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
