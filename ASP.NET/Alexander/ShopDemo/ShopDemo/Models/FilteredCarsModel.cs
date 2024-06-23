using Microsoft.AspNetCore.Mvc.Rendering;
using ShopDemo.DataAccess.Entities;

namespace ShopDemo.Models;

public class FilteredCarsModel
{

    public CarEntity[] FilteredCars { get; set; }
    public SelectList Categories { get; set; }
    public FilteredCarsModel(CarEntity[] filteredCars, SelectList categories)
    {
        FilteredCars = filteredCars;
        Categories = categories;
    }
}