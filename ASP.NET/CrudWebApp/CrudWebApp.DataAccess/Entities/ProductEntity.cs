namespace CrudWebApp.DataAccess.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int CategoryId { get; set; }

    public virtual CategoryEntity Category { get; set; } = null!;
}
