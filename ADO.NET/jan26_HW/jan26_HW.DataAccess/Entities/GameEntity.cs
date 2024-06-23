using jan26_HW.DataAccess.Enums;

namespace jan26_HW.DataAccess.Entities;

public class GameEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Developer { get; set; }
    public GameGenre Genre { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public GameMode Mode { get; set; }
    public int SoldCopies { get; set; }
}