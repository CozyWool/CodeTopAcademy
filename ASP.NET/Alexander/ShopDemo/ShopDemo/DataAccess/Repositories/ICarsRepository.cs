using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public interface ICarsRepository
{
    CarEntity[] GetAll();

    CarEntity[] GetFavouriteCars();
    CarEntity GetCarById(int carId);
    CarEntity[] GetCarByFilter(CarFilter carFilter);
}