using AutoMapper;
using CrudWeb.DataAccess.Entities;
using CrudWeb.DataAccess.Repositories;
using CrudWeb.Extensions;
using CrudWeb.Models;

namespace CrudWeb.Services;

public class ProductsService : IProductsService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductRepository productRepository;

    public ProductsService(IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        this.productRepository = productRepository;
        _categoryRepository = categoryRepository;
        this.mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public CategoryModel[] GetCategories()
    {
        return mapper.Map<CategoryModel[]>(_categoryRepository.GetAll());
    }

    public void Create(ProductModel model)
    {
        productRepository.Create(mapper.Map<ProductEntity>(model));
    }

    public void Delete(int id)
    {
        productRepository.Delete(id);
    }

    public ProductModel[] GetAll()
    {
        return mapper.Map<ProductModel[]>(productRepository.GetAll());
    }

    public PagedModel<ProductModel> GetPagedProducts(int currentPage, int pageSize = 10)
    {
        var items = mapper.Map<ProductModel[]>(productRepository.GetPagedProducts(currentPage, pageSize));
        var count = productRepository.GetAll().Length;
        return new PagedModel<ProductModel>
        {
            CurrentPage = currentPage,
            Count = count,
            PageSize = pageSize,
            Items = items.ToList()   
        };
    }

    public ProductModel GetById(int id)
    {
        var entity = productRepository.GetById(id);
        return mapper.Map<ProductModel>(entity);
    }

    public void Update(ProductModel model)
    {
        var oldEntity = productRepository.GetById(model.Id);
        if (oldEntity == null) return;
        oldEntity.Name = model.Name;
        oldEntity.Price = model.Price;
        oldEntity.CategoryId = model.CategoryId;
        productRepository.Update(oldEntity);
    }
    
    public void FillProductUri(params ProductModel[] products)
    {
        var baseUrl = _httpContextAccessor.HttpContext.Request.BaseUrl();;
        foreach (var product in products)
        {
            product.ImageUri = $"{baseUrl}api/Files/{product.Id}";
        }
    }

    public void FillProductUri(ProductModel product)
    {
        var baseUrl = _httpContextAccessor.HttpContext.Request.BaseUrl();;
        product.ImageUri = $"{baseUrl}api/Files/{product.Id}";
    }
}
