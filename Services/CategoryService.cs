using ApiProject.Models;
namespace ApiProject.Services;

public class CategoryService : ICategoryService
{
    TasksContext context;

    public CategoryService(TasksContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public async System.Threading.Tasks.Task Save(Category categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Update(Guid id, Category categoria)
    {
        var categoriaActual = context.Categories.Find(id);

        if (categoriaActual != null)
        {
            categoriaActual.Name = categoria.Name;
            categoria.Description = categoria.Description;
            categoria.Effort = categoria.Effort;

            await context.SaveChangesAsync();
        }
    }

    public async System.Threading.Tasks.Task Delete(Guid id)
    {
        var currentCategory = context.Categories.Find(id);

        if (currentCategory != null)
        {
            context.Remove(currentCategory);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    System.Threading.Tasks.Task Save(Category categoria);

    System.Threading.Tasks.Task Update(Guid id, Category categoria);

    System.Threading.Tasks.Task Delete(Guid id);
}