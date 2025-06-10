namespace TelegramBot.Web.Infrastructure.Configurations
{
    public class Intent
    {
        public IList<string> Examples { get; set; } = [];
        public IList<string> Responses { get; set; } = [];
    }
}
