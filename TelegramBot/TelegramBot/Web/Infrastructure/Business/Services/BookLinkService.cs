using TelegramBot.Application.Interfaces.Services;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class BookLinkService : IBookLinkService
    {
        private const string BaseUrl = "https://www.chitai-gorod.ru/product";

        public Uri Generate(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return new Uri(BaseUrl);

            return new Uri($"{BaseUrl}/{slug}");
        }
    }
}
