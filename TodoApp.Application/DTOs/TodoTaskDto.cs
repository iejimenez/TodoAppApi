using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.DTOs
{
    public class TodoTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get;  set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
