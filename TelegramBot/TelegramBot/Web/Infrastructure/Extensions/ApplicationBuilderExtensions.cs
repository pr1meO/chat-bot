using Microsoft.Extensions.Options;
using Microsoft.ML;
using Telegram.Bot;
using TelegramBot.Application.DTOs;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Shared.Constants;
using TelegramBot.Web.Controllers;
using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> UseDialogueSeederAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<IDialogueService>();

            await service.SeedAsync();

            return app;
        }

        public static IApplicationBuilder UseModelTraining(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MLContext>();
            var trainer = scope.ServiceProvider.GetRequiredService<ITrainer<IntentData>>();

            if (!File.Exists(ConfigurationFiles.Model))
            {
                var (model, schema) = trainer.Train();

                context.Model.Save(model, schema, ConfigurationFiles.Model);
            }

            return app;
        }
    }
}
