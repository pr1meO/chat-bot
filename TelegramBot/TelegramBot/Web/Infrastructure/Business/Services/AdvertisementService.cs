using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IBookService _bookService;
        private readonly IBookLinkService _linkService;

        public AdvertisementService(
            IBookService bookService, 
            IBookLinkService linkService)
        {
            _bookService = bookService;
            _linkService = linkService;
        }

        public async Task<string> GetBooksAsync(string response)
        {
            var books = await _bookService.GetRandomAsync();

            var replica = books
                .Select(b => string.Join(Separators.Line,
                [
                    $"📖 Автор: {b.Author}",
                    $"📖 Название: {b.Title}",
                    $"📖 Жанр: {b.Genre}",
                    $"📖 Цена: {b.Price} ₽",
                    $"📖 Описание: {b.Description}",
                    $"📖 Подробнее: {_linkService.Generate(b.Slug)}"
                ]))
                .ToList();

            return string.Concat(
                response,
                Separators.Line,
                string.Join(Separators.DoubleLine, replica));
        }
    }
}