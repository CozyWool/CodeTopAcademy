﻿namespace AuthRolesWeb.DataAccess.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}