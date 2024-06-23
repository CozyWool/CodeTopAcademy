using ShopDemoWebApp.DataAccess.Entities;

namespace ShopDemoWebApp.DataAccess.Repositories;

public interface ICarCategoryRepository
{
    CategoryEntity[] GetAll();
}