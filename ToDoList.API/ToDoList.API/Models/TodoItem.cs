namespace ToDoList.API.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
