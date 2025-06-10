using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Application.Interfaces.Commands
{
    public interface ICommand
    {
        string Name { get; }
        Task ExecuteAsync(Message message, ITelegramBotClient client);
    }
}
