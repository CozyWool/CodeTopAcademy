using CrudWebApp.DataAccess.Entities;
using CrudWebApp.Models;

namespace CrudWebApp.Services;

public interface IProductService
{
    List<ProductModel> GetAll();
    ProductModel GetById(int id);
    void Create(ProductModel model);
    void Update(ProductModel entity);
    void Delete(int id);
}