using CrudWebApp.DataAccess.Entities;

namespace CrudWebApp.DataAccess.Repositories;

public interface IProductRepository
{
    List<ProductEntity> GetAll();
    ProductEntity? GetById(int id);
    void Create(ProductEntity entity);
    void Update(ProductEntity entity);
    void Delete(int id);
}