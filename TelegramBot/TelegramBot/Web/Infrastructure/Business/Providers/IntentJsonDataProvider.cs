using Microsoft.Extensions.Options;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Web.Infrastructure.Business.Providers
{
    public class IntentJsonDataProvider<TOptions> : IJsonDataProvider<TOptions>
            where TOptions : class, IConfig
    {
        private readonly TOptions _value;

        public IntentJsonDataProvider(IOptions<TOptions> options)
        {
            _value = options.Value;
        }

        public IEnumerable<TSrc> Read<TSrc>(Func<string, string, TSrc> func)
            where TSrc : class, IData, new()
        {
            return _value.Intents
                .SelectMany(i => i.Value.Examples
                    .Select(e => func(e, i.Key)));
        }
    }
}
