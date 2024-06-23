using ShopDemo.DataAccess.Entities;

namespace ShopDemo.Models;

public class CarsModel
{
    public CarEntity[] Cars { get; set; }

    public string CurrentCategory { get; set; }
}