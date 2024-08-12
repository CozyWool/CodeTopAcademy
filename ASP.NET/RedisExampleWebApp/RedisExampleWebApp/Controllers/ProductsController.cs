using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RedisExampleWebApp.DataAccess.Contexts;
using RedisExampleWebApp.DataAccess.Entities;

namespace RedisExampleWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IDistributedCache _cache;

    public ProductsController(ApplicationDbContext dbContext, IDistributedCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var cacheKey = $"product-{id}";
        ProductEntity product;
        var cachedData = await _cache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            product = JsonSerializer.Deserialize<ProductEntity>(cachedData);
        }
        else
        {
            product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();
            var cachedDataString = JsonSerializer.Serialize(product);
            var options = GetCacheOptions();
            await _cache.SetStringAsync(cacheKey, cachedDataString, options);
        }

        
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductEntity product)
    {
        var oldProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (oldProduct == null)
        {
            return NotFound();
        }

        oldProduct.Name = product.Name;
        oldProduct.Price = product.Price;
        await _dbContext.SaveChangesAsync();
        var cacheKey = $"product-{id}";
        var cachedDataString = JsonSerializer.Serialize(product);
        var updatedProduct = Encoding.UTF8.GetBytes(cachedDataString);
        var options = GetCacheOptions();
        await _cache.SetAsync(cacheKey, updatedProduct, options);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        var cacheKey = $"product-{id}";
        await _cache.RemoveAsync(cacheKey);
        return NoContent();
    }

    private DistributedCacheEntryOptions GetCacheOptions() =>
        new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddHours(24))
            .SetSlidingExpiration(TimeSpan.FromHours(12));
}