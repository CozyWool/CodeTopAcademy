using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public class MockCarCategoryRepository : ICarCategoryRepository
{
    private readonly CategoryEntity[] _categoryEntities =
    {
        new()
        {
            Id = 1, CategoryName = "Электромобили", Description = "Современный вид транспорта"
        },
        new()
        {
            Id = 2, CategoryName = "Классические автомобили", Description = "Машины с двигателем внутреннего сгорания"
        }
    };

    public CategoryEntity[] GetAll() => _categoryEntities;

    public CategoryEntity GetById(int id)
    {
        return _categoryEntities.SingleOrDefault(x => x.Id == id);
    }
}