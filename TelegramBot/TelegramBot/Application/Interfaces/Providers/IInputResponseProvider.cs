namespace TelegramBot.Application.Interfaces.Providers
{
    public interface IInputResponseProvider
    {
        Task<string?> GetAsync(string input);
    }
}
