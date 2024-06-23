using AutoMapper;
using CrudWebApp.DataAccess.Entities;
using CrudWebApp.DataAccess.Repositories;
using CrudWebApp.Models;

namespace CrudWebApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public void Create(ProductModel model)
    {
        _productRepository.Create(_mapper.Map<ProductEntity>(model));
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }

    public List<ProductModel> GetAll()
    {
        return _mapper.Map<List<ProductModel>>(_productRepository.GetAll());
    }

    public ProductModel GetById(int id)
    {
        var entity = _productRepository.GetById(id);
        return _mapper.Map<ProductModel>(entity);
    }

    public void Update(ProductModel model)
    {
        var oldEntity = _productRepository.GetById(model.Id);
        if (oldEntity == null) return;

        oldEntity.Name = model.Name;
        oldEntity.Price = model.Price;
        oldEntity.CategoryId = model.CategoryId;
        
        _productRepository.Update(oldEntity);
    }
}