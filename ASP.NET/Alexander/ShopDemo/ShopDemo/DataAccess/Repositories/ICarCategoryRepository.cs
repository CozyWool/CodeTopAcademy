using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public interface ICarCategoryRepository
{
    CategoryEntity[] GetAll();
    CategoryEntity GetById(int id);
}