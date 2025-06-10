using Microsoft.Extensions.Options;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Web.Infrastructure.Business.Providers
{
    public class BotConfigResponseProvider : IIntentResponseProvider
    {
        private readonly BotConfig _config;
        private readonly Random _random;

        public BotConfigResponseProvider(
            IOptions<BotConfig> options,
            Random random)
        {
            _config = options.Value;
            _random = random;
        }

        public string? Get(string intent)
        {
            if (!_config.Intents.TryGetValue(intent, out Intent? data))
                return null; 

            if (!data.Responses.Any())
                return null;

            var index = _random.Next(data.Responses.Count);

            return data.Responses[index];
        }
    }
}