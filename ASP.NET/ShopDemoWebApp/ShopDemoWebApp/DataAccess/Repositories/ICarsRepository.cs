using ShopDemoWebApp.DataAccess.Entities;

namespace ShopDemoWebApp.DataAccess.Repositories;

public interface ICarsRepository
{
    CarEntity[] GetAll();
    CarEntity[] GetFavouriteCars();
    CarEntity GetCarById(int id);
}