using System.Speech.Synthesis;
using TelegramBot.Application.Interfaces.Speech;

namespace TelegramBot.Web.Infrastructure.Business.Speech
{
    public class SystemSpeechSynthesizer : ISpeechSynthesize
    {
        public Stream Synthesize(string replica)
        {
            var stream = new MemoryStream();

            using var speech = new SpeechSynthesizer();

            speech.SetOutputToWaveStream(stream);
            speech.Speak(replica);

            stream.Position = 0;

            return stream;
        }
    }
}
