using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LandingPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly ITelegramBotClient _botClient;
        public TelegramController()
        {
            _botClient = new TelegramBotClient("7110160322:AAFC4Iv-PYXM_nitQ3qReVT4-00eJSm5ue4");
        }
    }
}
