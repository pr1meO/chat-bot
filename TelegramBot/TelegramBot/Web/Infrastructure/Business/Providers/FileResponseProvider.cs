using TelegramBot.Application.Interfaces;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Web.Controllers;

namespace TelegramBot.Web.Infrastructure.Business.Providers
{
    public class FileResponseProvider : IFileResponseProvider
    {
        private readonly string _path;
        private readonly ITextPreprocessor _preprocessor;

        public FileResponseProvider(
            string path,
            ITextPreprocessor preprocessor)
        {
            _path = path;
            _preprocessor = preprocessor;
        }

        public IFileResponse Create()
        {
            return new FileResponse(
                _path,
                _preprocessor);
        }
    }
}
