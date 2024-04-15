using LandingPage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace LandingPage.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITelegramBotClient _telegramBotClient;
    public UserController(UserManager<User> userManager, SignInManager<User> signInManager,ITelegramBotClient telegramBotClient)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _telegramBotClient = telegramBotClient;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        long userId = 984891525;
        string message = $"Имя:{user.UserName}, Номер:{user.PhoneNumber}";
        _telegramBotClient.SendTextMessageAsync(userId, message);
        return RedirectToAction("Index");
    }
}