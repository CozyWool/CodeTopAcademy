using CrudWeb.DataAccess.Repositories;
using CrudWeb.Models;
using CrudWeb.Services;
using Microsoft.AspNetCore.Mvc;


namespace CrudWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public Task<ProductModel[]> GetAll()
        {
            return Task.FromResult(_productsService.GetAll());
        }
        [HttpGet("categories")]
        public Task<CategoryModel[]> GetAllCategories()
        {
            return Task.FromResult(_productsService.GetCategories());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productsService.GetById(id);
            if (product == null)
            {
                return NotFound(id);
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductModel productModel)
        {
            _productsService.Create(productModel);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ProductModel productModel)
        {
            _productsService.Update(productModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productsService.Delete(id);
            return Ok();
        }
    }
}