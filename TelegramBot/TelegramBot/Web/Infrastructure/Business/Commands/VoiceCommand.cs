using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Application.Interfaces.Speech;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Commands
{
    public class VoiceCommand : ICommand
    {
        private readonly IBotService _botService;
        private readonly ISpeechService _speechService;

        public string Name => CommandNames.Voice;

        public VoiceCommand(
            IBotService botService,
            ISpeechService speechService)
        {
            _botService = botService;
            _speechService = speechService;
        }

        public async Task ExecuteAsync(Message message, ITelegramBotClient client)
        {
            var file = await client.GetFile(message.Voice?.FileId!);

            using var stream = new MemoryStream();
            await client.DownloadFile(file.FilePath!, stream);

            stream.Position = 0;
            var replica = await _speechService.RecognizeAsync(stream);

            if (string.IsNullOrWhiteSpace(replica))
                return;

            await client.SendMessage(
                message.Chat.Id,
                $"📢 Вы сказали: {replica}",
                ParseMode.Markdown);

            var response = await _botService.GetResponseAsync(replica);

            using var audio = _speechService.Synthesize(response);

            audio.Position = 0;
            await client.SendAudio(
                chatId: message.Chat.Id,
                audio: InputFile.FromStream(audio),
                title: "Ответ от ChatBot",
                performer: "ChatBot");
        }
    }
}
