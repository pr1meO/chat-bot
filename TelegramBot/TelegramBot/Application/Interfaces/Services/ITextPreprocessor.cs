namespace TelegramBot.Application.Interfaces.Services
{
    public interface ITextPreprocessor
    {
        string? Preprocess(string replica);
    }
}
