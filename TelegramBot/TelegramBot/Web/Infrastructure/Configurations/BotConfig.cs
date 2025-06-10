using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Web.Infrastructure.Configurations
{
    public class BotConfig : IConfig
    {
        public Dictionary<string, Intent> Intents { get; set; } = [];
        public IList<string> Failures { get; set; } = [];
    }
}
