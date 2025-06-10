using NAudio.Wave;
using System.Text.Json;
using TelegramBot.Application.Interfaces.Speech;
using TelegramBot.Shared.Constants;
using Vosk;

namespace TelegramBot.Web.Infrastructure.Business.Speech
{
    public class VoskSpeechRecognizer : ISpeechRecognizer
    {
        private readonly IAudioConverter _converter;
        private readonly Model _model;

        public VoskSpeechRecognizer(
            IAudioConverter converter,
            Model model)
        {
            _converter = converter;
            _model = model;
        }

        public async Task<string?> RecognizeAsync(Stream inStream)
        {
            using var outStream = await _converter.ConvertToWavAsync(inStream);

            using var recognizer = new VoskRecognizer(_model, 16000.0f);
            using var reader = new RawSourceWaveStream(
                outStream,
                new WaveFormat(16000, 16, 1));

            byte[] buf = new byte[4096];
            while (reader.Read(buf, 0, buf.Length) > 0)
                recognizer.AcceptWaveform(buf, buf.Length);

            var result = recognizer.FinalResult();

            using var parser = JsonDocument.Parse(result);
            var replica = parser.RootElement.GetProperty(Sections.Text).GetString();

            return replica;
        }
    }
}
