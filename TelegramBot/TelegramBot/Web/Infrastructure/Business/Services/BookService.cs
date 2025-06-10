using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Domain.Entities;
using TelegramBot.Domain.Interfaces.Repositories;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Book>> GetRandomAsync()
        {
            return await _booksRepository.GetRandomAsync();
        }
    }
}
