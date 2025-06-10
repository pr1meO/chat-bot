using Microsoft.Extensions.Options;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Web.Infrastructure.Business.Providers
{
    public class BotConfigFailureResponseProvider : IFailureResponseProvider
    {
        private readonly BotConfig _config;
        private readonly Random _random;

        public BotConfigFailureResponseProvider(
            IOptions<BotConfig> options,
            Random random)
        {
            _config = options.Value;
            _random = random;
        }

        public string Get()
        {
            var index = _random.Next(_config.Failures.Count);

            return _config.Failures[index];
        }
    }
}
