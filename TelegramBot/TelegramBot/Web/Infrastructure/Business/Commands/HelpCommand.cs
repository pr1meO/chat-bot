using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => CommandNames.Help;

        public async Task ExecuteAsync(Message message, ITelegramBotClient client)
        {
            await client.SendMessage(
                message.Chat.Id,
                """
                🤖 *Доступные команды:*

                `/start` — начать общение с ботом
                `/help` — список доступных команд

                💡 Просто напиши фразу — я постараюсь понять тебя и помочь!
                """,
               ParseMode.Markdown);
        }
    }
}
