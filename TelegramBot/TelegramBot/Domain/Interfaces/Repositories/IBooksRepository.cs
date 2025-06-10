using TelegramBot.Domain.Entities;

namespace TelegramBot.Domain.Interfaces.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetRandomAsync();
    }
}
