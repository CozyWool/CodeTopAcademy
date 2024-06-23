using CrudWebApp.DataAccess.Contexts;
using CrudWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApp.DataAccess.Repositories;

public class DbProductRepository : IProductRepository
{
    private readonly ProductsDbContext _productsDbContext;

    public DbProductRepository(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public List<ProductEntity> GetAll()
    {
        return _productsDbContext
            .Products
            .Include(x => x.Category)
            .ToList();
    }

    public ProductEntity? GetById(int id)
    {
        return _productsDbContext
            .Products
            .Include(x => x.Category)
            .FirstOrDefault(entity => entity.Id == id);
    }

    public void Create(ProductEntity entity)
    {
        if (entity.Id <= 0)
        {
            entity.Id = GetAll().Last().Id + 1;
        }
        _productsDbContext.Products.Add(entity);
        _productsDbContext.SaveChanges();
    }

    public void Update(ProductEntity entity)
    {
        _productsDbContext.Update(entity);
        _productsDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity == null) return;
        _productsDbContext.Products.Remove(entity);
        _productsDbContext.SaveChanges();
    }
}