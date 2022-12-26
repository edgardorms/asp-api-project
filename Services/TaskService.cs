using ApiProject.Models;
using Tarea = ApiProject.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace ApiProject.Services;

public class TareasService : ITareasService
{
    TasksContext context;

    public TareasService(TasksContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tasks;
    }

    public async Task Save(Tarea Tarea)
    {
        Tarea.DateTimeCreated = DateTime.Now;
        context.Add(Tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea Tarea)
    {
        var CurrentTask = context.Tasks.Find(id);

        if (CurrentTask != null)
        {
            CurrentTask.Title = Tarea.Title;
            Tarea.Description = Tarea.Description;
            Tarea.TaskPriority = Tarea.TaskPriority;
            Tarea.CategoryId = Tarea.CategoryId;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var CurrentTask = context.Tasks.Find(id);

        if (CurrentTask != null)
        {
            context.Remove(CurrentTask);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea Tarea);

    Task Update(Guid id, Tarea Tarea);

    Task Delete(Guid id);
}