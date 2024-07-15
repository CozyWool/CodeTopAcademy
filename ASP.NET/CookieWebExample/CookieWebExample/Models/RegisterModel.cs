using System.ComponentModel.DataAnnotations;

namespace CookieWebExample.Models;

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
}