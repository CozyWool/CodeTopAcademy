namespace RedisExampleWebApp.DataAccess.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public ProductEntity()
    {
        
    }

    public ProductEntity(Guid id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}