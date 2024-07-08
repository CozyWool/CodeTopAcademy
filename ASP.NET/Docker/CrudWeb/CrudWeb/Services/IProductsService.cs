using CrudWeb.Models;

namespace CrudWeb.Services;

public interface IProductsService
{
    ProductModel[] GetAll();
    PagedModel<ProductModel> GetPagedProducts(int currentPage, int pageSize = 10);
    ProductModel GetById(int id);
    CategoryModel[] GetCategories();
    void Create(ProductModel model);
    void Update(ProductModel model);
    void Delete(int id);
    void FillProductUri(ProductModel product);
    void FillProductUri(params ProductModel[] products);
}