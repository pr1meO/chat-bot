namespace TelegramBot.Application.Interfaces.Providers
{
    public interface IIntentResponseProvider
    {
        string? Get(string intent);
    }
}
