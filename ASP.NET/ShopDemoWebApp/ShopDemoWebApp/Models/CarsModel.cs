using ShopDemoWebApp.DataAccess.Entities;

namespace ShopDemoWebApp.Models;

public class CarsModel
{
    public CarEntity[] Cars { get; set; }
    public string CurrentCategory { get; set; }
}