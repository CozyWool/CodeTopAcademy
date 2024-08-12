using LibraryWebApplication.Enums;

namespace LibraryWebApplication.DataAccess.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateOnly Birthday { get; set; }
}