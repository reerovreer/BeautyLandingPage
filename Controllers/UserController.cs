using LandingPage.Models;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace LandingPage.Controllers;

public class UserController : Controller
{
    private readonly UserContext _db;
    private readonly ITelegramBotClient _telegramBotClient;
    public UserController(UserContext db, ITelegramBotClient telegramBotClient)
    {
        _db = db;
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
        string message = $"Имя:{user.UserName}, Номер:{user.UserNumber}";
        _telegramBotClient.SendTextMessageAsync(userId, message);
        return RedirectToAction("Index");
    }
}