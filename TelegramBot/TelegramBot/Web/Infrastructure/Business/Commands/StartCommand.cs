using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Commands
{
    public class StartCommand : ICommand
    {
        public string Name { get; } = CommandNames.Start;

        public async Task ExecuteAsync(Message message, ITelegramBotClient client)
        {
            await client.SendMessage(
                message.Chat.Id,
               """
                Привет! 👋  
                Я — твой персональный помощник. Готов поболтать, ответить на вопросы, посоветовать книгу 😊

                Напиши что-нибудь, например:
                • 📘 «Как справиться с тревогой?»
                • 🎲 «Чем заняться, когда скучно?»
                • 🤔 «Расскажи что-нибудь интересное»

                Готов? Погнали! 🚀
                """,
                ParseMode.Markdown);
        }
    }
}
