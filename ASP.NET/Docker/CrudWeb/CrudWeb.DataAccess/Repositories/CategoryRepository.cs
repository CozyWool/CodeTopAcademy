using CrudWeb.DataAccess.Contexts;
using CrudWeb.DataAccess.Entities;

namespace CrudWeb.DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductsDbContext _productsDbContext;

    public CategoryRepository(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public CategoryEntity[] GetAll()
    {
        return _productsDbContext.Categories.ToArray();
    }
}