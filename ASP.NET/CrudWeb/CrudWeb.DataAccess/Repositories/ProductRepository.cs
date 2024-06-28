using CrudWeb.DataAccess.Contexts;
using CrudWeb.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudWeb.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext productsDbContext;

        public ProductRepository(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }
        public void Create(ProductEntity entity)
        {
            productsDbContext.Products.Add(entity);
            productsDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            productsDbContext.Products.Remove(entity);
            productsDbContext.SaveChanges();
        }

        public ProductEntity GetById(int id)
        {
            return productsDbContext
                                .Products
                                .Include(x => x.Category)
                                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(ProductEntity entity)
        {
            productsDbContext.Update(entity);
            productsDbContext.SaveChanges();
        }

        ProductEntity[] IProductRepository.GetAll()
        {
            return productsDbContext
                                    .Products
                                    .Include(x => x.Category)
                                    .OrderBy(x => x.Id)
                                    .ToArray();
        }
    }
}
