using System.ComponentModel.DataAnnotations;

namespace LandingPage.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Заполните имя пользователя")]
    [Display(Name = "Укажите имя пользователя")]
    public string UserName { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Заполните Email адрес")]
    [Display(Name = "Укажите Email адрес")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Введите пароль")]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Compare(nameof(Password),ErrorMessage = "Пароли не совпадают")]
    [Display(Name = "Повторите пароль")]
    public string ConfirmPassword { get; set; }
}