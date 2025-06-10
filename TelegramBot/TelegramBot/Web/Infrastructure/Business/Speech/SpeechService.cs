using TelegramBot.Application.Interfaces.Speech;

namespace TelegramBot.Web.Infrastructure.Business.Speech
{
    public class SpeechService : ISpeechService
    {
        private readonly ISpeechRecognizer _recognizer;
        private readonly ISpeechSynthesize _synthesize;

        public SpeechService(
            ISpeechRecognizer recognizer,
            ISpeechSynthesize synthesize)
        {
            _recognizer = recognizer;
            _synthesize = synthesize;
        }

        public async Task<string?> RecognizeAsync(Stream inStream)
        {
            return await _recognizer.RecognizeAsync(inStream);
        }

        public Stream Synthesize(string replica)
        {
            return _synthesize.Synthesize(replica);
        }
    }
}
