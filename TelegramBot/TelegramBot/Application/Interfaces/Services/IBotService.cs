namespace TelegramBot.Application.Interfaces.Services
{
    public interface IBotService
    {
        Task<string> GetResponseAsync(string replica);
    }
}
