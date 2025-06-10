using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Application.Interfaces.Providers
{
    public interface IJsonDataProvider<TOptions>
        where TOptions : class, IConfig
    {
        IEnumerable<TSrc> Read<TSrc>(Func<string, string, TSrc> func)
            where TSrc : class, IData, new();
    }
}
