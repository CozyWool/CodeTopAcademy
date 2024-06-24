using AutoMapper;
using CrudWeb.DataAccess.Entities;
using CrudWeb.DataAccess.Repositories;
using CrudWeb.Models;

namespace CrudWeb.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        public ProductsService(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
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
    }
}