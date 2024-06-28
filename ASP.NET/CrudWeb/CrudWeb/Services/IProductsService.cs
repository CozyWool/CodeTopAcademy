using CrudWeb.Models;

namespace CrudWeb.Services;

public interface IProductsService
{
    ProductModel[] GetAll();
    ProductModel GetById(int id);
    CategoryModel[] GetCategories();
    void Create(ProductModel model);
    void Update(ProductModel model);
    void Delete(int id);
}