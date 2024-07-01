using ShopDemo.DataAccess.Contexts;
using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public class DbCarCategoryRepository : ICarCategoryRepository
{
    private readonly CarsDbContext _carsDbContext;

    public DbCarCategoryRepository(CarsDbContext carsDbContext)
    {
        _carsDbContext = carsDbContext;
    }

    public CategoryEntity[] GetAll()
    {
        return _carsDbContext.Categories.ToArray();
    }

    public CategoryEntity GetById(int id)
    {
        return _carsDbContext.Categories.FirstOrDefault(entity => entity.Id == id);
    }
}