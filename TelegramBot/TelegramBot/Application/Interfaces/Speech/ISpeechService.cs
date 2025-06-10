namespace TelegramBot.Application.Interfaces.Speech
{
    public interface ISpeechService
    {
        Task<string?> RecognizeAsync(Stream inStream);
        Stream Synthesize(string replica);
    }
}
