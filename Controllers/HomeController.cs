using LandingPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace LandingPage.Controllers;

public class HomeController : Controller
{
    private readonly ITelegramBotClient _telegramBotClient;
    public HomeController(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }
    [HttpGet,AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost,AllowAnonymous]
    public IActionResult GetConsult(User user)
    {
        long userId = 984891525;
        string message = $"Имя:{user.UserName}, Номер:{user.PhoneNumber}";
        _telegramBotClient.SendTextMessageAsync(userId, message);
        return RedirectToAction("Index");
    }
}