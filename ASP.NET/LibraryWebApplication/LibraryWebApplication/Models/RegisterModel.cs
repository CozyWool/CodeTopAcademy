using System.ComponentModel.DataAnnotations;
using LibraryWebApplication.Enums;

namespace LibraryWebApplication.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Укажите эл. почту")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Эл. почта")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Повторите пароль")]
    [Display(Name = "Повторите пароль")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Укажите роль")]
    [Display(Name = "Роль")]
    [EnumDataType(typeof(Role))]
    public Role Role { get; set; }
    
    [Required(ErrorMessage = "Укажите дату рождения")]
    [Display(Name = "Дата рождения")]
    [DataType(DataType.Date)]
    public DateOnly Birthday { get; set; }
}