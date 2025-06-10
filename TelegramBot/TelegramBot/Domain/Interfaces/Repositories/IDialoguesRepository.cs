using TelegramBot.Domain.Entities;

namespace TelegramBot.Domain.Interfaces.Repositories
{
    public interface IDialoguesRepository
    {
        Task AddRangeAsync(IEnumerable<Dialogue> dialogues);
        Task<IEnumerable<Dialogue>> GetByLengthAsync(int length, int tolerance);
        Task<bool> ExistsAsync();
    }
}
