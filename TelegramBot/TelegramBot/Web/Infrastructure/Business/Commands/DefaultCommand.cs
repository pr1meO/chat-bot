using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Commands
{
    public class DefaultCommand : ICommand
    {
        private readonly IBotService _botService;

        public string Name => CommandNames.Default;

        public DefaultCommand(IBotService botService)
        {
            _botService = botService;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient client)
        {
            var replica = message.Text;

            var response = await _botService.GetResponseAsync(replica!);

            await client.SendMessage(message.Chat.Id, response, ParseMode.Markdown);
        }
    }
}
