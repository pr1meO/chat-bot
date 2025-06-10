using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Domain.Interfaces
{
    public interface IConfig
    {
        Dictionary<string, Intent> Intents { get; set; }
        IList<string> Failures { get; set; }
    }
}
