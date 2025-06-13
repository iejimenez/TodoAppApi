using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Application.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRespository _todoTaskRepository;
        public TodoTaskService(ITodoTaskRespository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }
        public async Task<IEnumerable<TodoTaskDto>> GetAllAsync()
        {
            var todoTask = await _todoTaskRepository.GetAllAsync();
            return MapToDtoList(todoTask);
        }

        public async Task<TodoTaskDto> GetByIdAsync(Guid id)
        {
            var todoTask = await _todoTaskRepository.GetByIdAsync(id);
            return MapToDto(todoTask);
        }

        private static TodoTaskDto MapToDto(TodoTask todo)
        {
            return new TodoTaskDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
                CompletedAt = todo.CompletedAt
            };
        }

        private static IEnumerable<TodoTaskDto> MapToDtoList(IEnumerable<TodoTask> todoTasks)
        {
            var dtoList = new List<TodoTaskDto>();
            foreach (var todoTask in todoTasks)
            {
                dtoList.Add(MapToDto(todoTask));
            }
            return dtoList;
        }
    }
}
