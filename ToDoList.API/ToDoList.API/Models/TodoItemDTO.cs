using System.ComponentModel.DataAnnotations;

namespace ToDoList.API.Models
{
    public class TodoItemDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; } 
        public bool IsCompleted { get; set; }
    }
}
