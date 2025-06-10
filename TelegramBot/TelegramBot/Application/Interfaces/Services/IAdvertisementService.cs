namespace TelegramBot.Application.Interfaces.Services
{
    public interface IAdvertisementService
    {
        Task<string> GetBooksAsync(string response);
    }
}
