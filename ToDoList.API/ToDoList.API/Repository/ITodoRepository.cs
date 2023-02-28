using ToDoList.API.Models;

namespace ToDoList.API.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(Guid id);
        Task AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(Guid id);
    }
}
