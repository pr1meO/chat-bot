namespace TelegramBot.Application.Interfaces.Services
{
    public interface IDialogueService
    {
        Task SeedAsync();
        Task<string?> MatchAsync(string input);
    }
}
