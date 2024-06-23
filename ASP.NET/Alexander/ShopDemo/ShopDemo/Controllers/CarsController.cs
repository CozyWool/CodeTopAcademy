using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopDemo.DataAccess.Repositories;
using ShopDemo.Models;

namespace ShopDemo.Controllers;

[Route("cars")]
public class CarsController : Controller
{
    private readonly ICarsRepository _carsRepository;
    private readonly ICarCategoryRepository _carCategoryRepository;

    public CarsController(ICarsRepository carsRepository, ICarCategoryRepository carCategoryRepository)
    {
        _carsRepository = carsRepository;
        _carCategoryRepository = carCategoryRepository;
    }

    [Route("/")]
    [HttpGet("list")]
    public ViewResult List()
    {
        ViewBag.Title = "Страница с авто";
        var viewModel = new CarsModel
        {
            Cars = _carsRepository.GetAll(),
            CurrentCategory = "Автомобили"
        };
        return View(viewModel);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var entity = _carsRepository.GetCarById(id);
        if (entity == null)
        {
            return NotFound(id);
        }

        var category = _carCategoryRepository.GetById(entity.CategoryId);
        var carModel = new CarModel
        {
            Id = entity.Id,
            Name = entity.Name,
            LongDescription = entity.LongDescription,
            Image = entity.Image,
            Price = entity.Price,
            Available = entity.Available,
            CategoryName = category.CategoryName
        };
        return View("CarDetails", carModel);
    }

    [HttpGet]
    public IActionResult FilterCars([FromQuery(Name = "car")] string carName,
        [FromQuery(Name = "category")] int? categoryId = null)
    {
        ViewBag.Title = "Авто по критерию";
        
        var categories = _carCategoryRepository.GetAll();
        var carFilter = new CarFilter
        {
            CarName = carName,
            CategoryId = categoryId
        };

        var filteredCars = _carsRepository.GetCarByFilter(carFilter);

        var selectList = new SelectList(categories, "Id", "CategoryName");
        var filteredCarsModel = new FilteredCarsModel(filteredCars, selectList);
        return View("FilteredCars", filteredCarsModel);
    }
}