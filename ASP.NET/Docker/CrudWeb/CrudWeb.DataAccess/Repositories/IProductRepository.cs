using CrudWeb.DataAccess.Entities;

namespace CrudWeb.DataAccess.Repositories;

public interface IProductRepository
{
    ProductEntity[] GetAll();
    ProductEntity GetById(int id);
    void Create(ProductEntity model);
    void Update(ProductEntity model);
    void Delete(int id);
    void UpdateImage(int id, byte[] bytesData);
    ProductEntity[] GetPagedProducts(int currentPage, int pageSize = 10);
}