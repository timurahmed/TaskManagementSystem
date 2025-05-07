using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data
{
    public class TaskManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        public TaskManagerDbContext() { }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=TaskSystem;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}
