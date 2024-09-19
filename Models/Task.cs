namespace ToDoApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string TaskName { get; set; }
        public bool State { get; set; }
    }
}
