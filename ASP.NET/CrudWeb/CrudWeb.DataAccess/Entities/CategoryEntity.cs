namespace CrudWeb.DataAccess.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}