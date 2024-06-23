using CrudWebApp.DataAccess.Entities;

namespace CrudWebApp.DataAccess.Repositories;

public class FakeProductRepository : IProductRepository
{
    private readonly List<ProductEntity> _products =
    [
        new() {Id = 1, Name = "Яблоки", Price = 120},
        new() {Id = 2, Name = "Вода", Price = 120},
        new() {Id = 3, Name = "Шоколад", Price = 120},
        new() {Id = 4, Name = "Конфеты", Price = 120},
    ];

    public List<ProductEntity> GetAll()
    {
        return _products;
    }

    public ProductEntity? GetById(int id)
    {
        return _products.FirstOrDefault(entity => entity.Id == id);
    }

    public void Create(ProductEntity entity)
    {
        _products.Add(entity);
    }

    public void Update(ProductEntity entity)
    {
        var oldModel = _products.FirstOrDefault(x => entity.Id == x.Id);
        if (oldModel == null)
        {
            return;
        }

        oldModel.Name = entity.Name;
        oldModel.Price = entity.Price;
    }

    public void Delete(int id)
    {
        var model = _products.FirstOrDefault(x => x.Id == id);
        if (model == null) return;
        _products.Remove(model);
    }
}