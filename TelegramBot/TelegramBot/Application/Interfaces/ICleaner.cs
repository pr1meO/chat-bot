namespace TelegramBot.Application.Interfaces
{
    public interface ICleaner
    {
        string Clean(string replica);
        string NormalizeSpaces(string replica);
    }
}
