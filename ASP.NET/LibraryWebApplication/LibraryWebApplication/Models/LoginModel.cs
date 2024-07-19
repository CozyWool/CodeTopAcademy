using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Укажите эл. почту")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Эл. почта")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Запомнить")] public bool RememberMe { get; set; }
}