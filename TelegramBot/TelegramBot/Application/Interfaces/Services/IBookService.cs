using TelegramBot.Domain.Entities;

namespace TelegramBot.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetRandomAsync();
    }
}
