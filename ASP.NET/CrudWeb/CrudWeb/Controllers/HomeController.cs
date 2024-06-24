using CrudWeb.Models;
using CrudWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly CategoryModel[] _categories;

        public HomeController(IProductsService productsService)
        {
            this._productsService = productsService;
            _categories = _productsService.GetCategories();
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_productsService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productsService.GetById(id);
            return View("ProductDetails", product);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var productViewModel = new ProductViewModel
            {
                Categories = _categories
            };
            return View("CreateProduct", productViewModel);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm(Name = "Product")] ProductModel productModel)
        {
            _productsService.Create(productModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var productModel = _productsService.GetById(id);
            var productViewModel = new ProductViewModel
            {
                Product = productModel,
                Categories = _categories
            };
            return View("EditProduct", productViewModel);
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromForm(Name = "Product")] ProductModel productModel)
        {
            _productsService.Update(productModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productsService.Delete(id);
            return Ok();
        }
    }
}