namespace TelegramBot.Application.Interfaces.Speech
{
    public interface ISpeechRecognizer
    {
        Task<string?> RecognizeAsync(Stream inStream);
    }
}
