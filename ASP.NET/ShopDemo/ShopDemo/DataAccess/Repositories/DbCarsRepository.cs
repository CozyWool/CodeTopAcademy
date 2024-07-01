using Microsoft.EntityFrameworkCore;
using ShopDemo.DataAccess.Contexts;
using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Repositories;

public class DbCarsRepository : ICarsRepository
{
    private readonly CarsDbContext _carsDbContext;

    public DbCarsRepository(CarsDbContext carsDbContext)
    {
        _carsDbContext = carsDbContext;
    }

    public CarEntity[] GetAll()
    {
        return _carsDbContext.Cars.ToArray();
    }

    public CarEntity[] GetFavouriteCars()
    {
        return _carsDbContext.Cars.Where(x => x.IsFavourite).ToArray();
    }

    public CarEntity GetCarById(int carId)
    {
        return _carsDbContext.Cars.FirstOrDefault(entity => entity.Id == carId);
    }

    public CarEntity[] GetCarByFilter(CarFilter carFilter)
    {
        var query = _carsDbContext.Cars.AsQueryable();
        if (!string.IsNullOrEmpty(carFilter.CarName))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{carFilter.CarName}%"));
        }

        if (carFilter.CategoryId.HasValue)
        {
            query = query.Where(x => x.CategoryId == carFilter.CategoryId);
        }

        return query.ToArray();
    }
}