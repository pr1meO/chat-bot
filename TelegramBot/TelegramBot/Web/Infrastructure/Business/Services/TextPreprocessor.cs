using TelegramBot.Application.Interfaces;
using TelegramBot.Application.Interfaces.Services;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class TextPreprocessor : ITextPreprocessor
    {
        private readonly ICleaner _cleaner;
        private readonly ILemmatizer _lemmatizer;

        public TextPreprocessor(
            ICleaner cleaner,
            ILemmatizer lemmatizer)
        {
            _cleaner = cleaner;
            _lemmatizer = lemmatizer;
        }

        public string? Preprocess(string replica)
        {
            var cleaned = _cleaner.Clean(replica);

            if (string.IsNullOrWhiteSpace(cleaned))
                return null;

            return _lemmatizer.Lemmatize(cleaned);
        }
    }
}
