using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Application.Interfaces.Commands;

namespace TelegramBot.Web.Controllers
{
    [ApiController]
    [Route("api/telegram/bot")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecutor _executor;

        public TelegramBotController(ICommandExecutor executor)
        {
            _executor = executor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            await _executor.ExecuteAsync(update);

            return Ok();
        }
    }
}
