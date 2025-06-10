using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Application.Interfaces
{
    public interface IFileResponse
    {
        Task<IEnumerable<T>> ReadAsync<T>() where T : IDialogue, new();
    }
}
