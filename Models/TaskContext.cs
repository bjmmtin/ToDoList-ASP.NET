using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
    {
        public DbSet<Task> Tasks { get; set; }
    }
}
