using System.ComponentModel.DataAnnotations;

namespace LandingPage.ViewModels;

public class LoginViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Заполните Email адрес")]
    [Display(Name = "Укажите Email адрес")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Введите пароль")]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}