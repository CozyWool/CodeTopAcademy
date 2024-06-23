using Microsoft.AspNetCore.Mvc;
using ShopDemoWebApp.DataAccess.Repositories;
using ShopDemoWebApp.Models;

namespace ShopDemoWebApp.Controllers;

public class CarsController : Controller
{
    private readonly ICarsRepository _carsRepository;
    private readonly ICarCategoryRepository _carCategoryRepository;

    public CarsController(ICarsRepository carsRepository, ICarCategoryRepository carCategoryRepository)
    {
        _carsRepository = carsRepository;
        _carCategoryRepository = carCategoryRepository;
    }

    public ViewResult List()
    {
        ViewBag.Title = "Страница с авто";
        var viewModel = new CarsModel()
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

        throw new NotImplementedException();
    }
}