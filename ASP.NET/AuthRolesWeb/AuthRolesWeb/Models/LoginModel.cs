using System.ComponentModel.DataAnnotations;

namespace AuthRolesWeb.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Укажите Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Запомнить")] public bool RememberMe { get; set; }
}

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

    [Required]
    public string Role { get; set; }
}