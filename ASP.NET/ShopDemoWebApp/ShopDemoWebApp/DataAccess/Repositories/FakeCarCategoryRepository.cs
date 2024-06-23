using ShopDemoWebApp.DataAccess.Entities;

namespace ShopDemoWebApp.DataAccess.Repositories;

public class FakeCarCategoryRepository : ICarCategoryRepository
{
    public CategoryEntity[] GetAll()
    {
        return new[]
        {
            new CategoryEntity {CategoryName = "Электромобили", Description = "Современный вид транспорта"},
            new CategoryEntity {CategoryName = "Классические автомобили", Description = "Машины с ДВС"}
        };
    }
}