using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Укажите Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Укажите роль")] 
    public string Role { get; set; }
    
    [Required(ErrorMessage = "Укажите дату рождения")]
    [DataType(DataType.Date)]
    public DateOnly Birthday { get; set; }
}