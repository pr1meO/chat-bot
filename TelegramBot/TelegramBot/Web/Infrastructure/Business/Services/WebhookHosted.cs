using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class WebhookHosted : IHostedService
    {
        private readonly IServiceProvider _provider;

        public WebhookHosted(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken ct)
        {
            using var scope = _provider.CreateScope();

            var client = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            var url = scope.ServiceProvider.GetRequiredService<IOptions<BotOptions>>().Value.Url;

            await client.SetWebhook($"{url}/api/telegram/bot", cancellationToken: ct);
        }

        public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
    }
}
