using Microsoft.EntityFrameworkCore;
using ToDoList.API.Models;

namespace ToDoList.API.Data
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
