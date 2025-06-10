using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommand _voice;
        private readonly ICommand _command;
        private readonly ITelegramBotClient _client;
        private readonly Dictionary<string, ICommand> _handlers;

        public CommandExecutor(
            IEnumerable<ICommand> handlers,
            ITelegramBotClient client)
        {
            _client = client;
            _handlers = handlers.ToDictionary(h => h.Name);
            _command = _handlers.First(h => h.Key == CommandNames.Default).Value;
            _voice = _handlers.First(h => h.Key == CommandNames.Voice).Value;
        }

        public async Task ExecuteAsync(Update update)
        {
            var message = update.Message;

            if (message?.Voice is not null)
            {
                await _voice.ExecuteAsync(message, _client);
                return;
            }

            if (message?.Text is null)
                return;

            var replica = message.Text.Trim();

            if (_handlers.TryGetValue(replica, out var handler))
            {
                await handler.ExecuteAsync(message, _client);
                return;
            }

            await _command.ExecuteAsync(message, _client);
        }
    }
}
