namespace ShopDemo.Models;

public class CarModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LongDescription { get; set; }

    public string Image { get; set; }

    public uint Price { get; set; }

    public bool Available { get; set; }

    public string CategoryName { get; set; }
}