using Telegram.Bot.Types;

namespace TelegramBot.Application.Interfaces.Commands
{
    public interface ICommandExecutor
    {
        Task ExecuteAsync(Update update);
    }
}
