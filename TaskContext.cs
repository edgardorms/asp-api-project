using Microsoft.EntityFrameworkCore;
using ApiProject.Models;
using Task = ApiProject.Models.Task;

namespace ApiProject
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category() { CategoryId = Guid.Parse("6fc268ea-c5fe-4ffb-986c-389e196a0763"), Name ="actividades pendientes", Effort= 50});

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categoria");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired().HasMaxLength(100); ;
                category.Property(p => p.Description).IsRequired(false);
                category.Property(p => p.Effort);
                category.HasData(categoriesInit);
            });


            List<Task> tasksInit = new List<Task>();
            tasksInit.Add(new Task() { TaskId = Guid.Parse("6fc268ea-c5fe-4ffb-986c-389e196a0565"), CategoryId = Guid.Parse("6fc268ea-c5fe-4ffb-986c-389e196a0763") , Title = "tarea 1",TaskPriority = Priority.Low,}) ;

            modelBuilder.Entity<Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                task.Property(p => p.Title).HasMaxLength(100);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p => p.TaskPriority);
                task.Property(p => p.DateTimeCreated);
                task.HasData(tasksInit);
            });

        }
    }
}
