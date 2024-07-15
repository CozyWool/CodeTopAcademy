using System.ComponentModel.DataAnnotations;

namespace CookieWebExample.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Укажите Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}