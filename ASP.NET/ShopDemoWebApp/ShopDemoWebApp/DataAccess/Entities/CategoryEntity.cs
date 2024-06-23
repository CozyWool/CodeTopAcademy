namespace ShopDemoWebApp.DataAccess.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public List<CarEntity> Cars { get; set; }
}