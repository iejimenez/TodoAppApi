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

        
        public async Task<TodoTaskDto> CreateAsync(CreateTodoTaskDto createTodoTaskDto)
        {
            var todoTask = new TodoTask(createTodoTaskDto.Title, createTodoTaskDto.Description, createTodoTaskDto.Status, createTodoTaskDto.ExpirationDate);
            await _todoTaskRepository.AddAsync(todoTask);
            return MapToDto(todoTask);
        }

        public async Task<TodoTaskDto> UpdateAsync(Guid id, UpdateTodoTaskDto updateTodoDto)
        {
            var todoTaskBd = await _todoTaskRepository.GetByIdAsync(id);
            if (todoTaskBd == null)
                throw new KeyNotFoundException($"La tarea con ID {id} no fue encontrada.");

            todoTaskBd.Update(updateTodoDto.Title, updateTodoDto.Description, updateTodoDto.Status, updateTodoDto.ExpirationDate);
            await _todoTaskRepository.UpdateAsync(todoTaskBd);
            return MapToDto(todoTaskBd);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _todoTaskRepository.DeleteAsync(id);
        }
        private static TodoTaskDto MapToDto(TodoTask todoTask)
        {
            return new TodoTaskDto
            {
                Id = todoTask.Id,
                Title = todoTask.Title,
                Description = todoTask.Description,
                Status = todoTask.Status,
                ExpirationDate = todoTask.ExpirationDate,
                CreatedAt = todoTask.CreatedAt,
                CompletedAt = todoTask.CompletedAt
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
