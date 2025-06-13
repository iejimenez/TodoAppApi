using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TodoTask
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ExpirationDate { get;private set; }

        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        private TodoTask() { } // For EF Core

        public TodoTask(string title, string description, string status, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Status = status;
            ExpirationDate = expirationDate;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string title, string description, string status, DateTime expirationDate)
        {
            Title = title;
            Description = description;
            Status = status;
            ExpirationDate = expirationDate;
        }
    }
}
