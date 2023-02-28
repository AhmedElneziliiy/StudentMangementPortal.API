namespace ToDoList.API.Models
{
    public class TodoItemCreateDTO
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsComplete { get; set; }
    }
}
