using Microsoft.Extensions.ML;
using Microsoft.Extensions.Options;
using Microsoft.ML;
using Nestor;
using Telegram.Bot;
using TelegramBot.Application.DTOs;
using TelegramBot.Application.Implementations;
using TelegramBot.Application.Interfaces;
using TelegramBot.Application.Interfaces.Commands;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Application.Interfaces.Speech;
using TelegramBot.Domain.Interfaces.Repositories;
using TelegramBot.Shared.Constants;
using TelegramBot.Web.Infrastructure.Business;
using TelegramBot.Web.Infrastructure.Business.Commands;
using TelegramBot.Web.Infrastructure.Business.MachineLearning;
using TelegramBot.Web.Infrastructure.Business.Providers;
using TelegramBot.Web.Infrastructure.Business.Repository;
using TelegramBot.Web.Infrastructure.Business.Services;
using TelegramBot.Web.Infrastructure.Business.Speech;
using TelegramBot.Web.Infrastructure.Configurations;
using Vosk;

namespace TelegramBot.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTextPreprocessing(
            this IServiceCollection services)
        {
            services.AddScoped<ICleaner, CleanerIsRegex>();
            services.AddScoped<ILevenshtein, LevenshteinIsFastenshtein>();
            services.AddScoped<ILemmatizer, LemmatizerIsNestor>();
            services.AddScoped<ITextPreprocessor, TextPreprocessor>();
            services.AddScoped<NestorMorph>();

            return services;
        }

        public static IServiceCollection AddTelegramBot(
            this IServiceCollection services)
        {
            services.AddScoped<IBotService, BotService>();
            services.AddSingleton<ITelegramBotClient>(sp =>
            {
                var token = sp.GetRequiredService<IOptions<BotOptions>>().Value.Token;

                return new TelegramBotClient(token);
            });

            return services;
        }

        public static IServiceCollection AddSpeech(
            this IServiceCollection services)
        {
            services.AddScoped<ISpeechService, SpeechService>();
            services.AddScoped<ISpeechRecognizer, VoskSpeechRecognizer>();
            services.AddScoped<ISpeechSynthesize, SystemSpeechSynthesizer>();
            services.AddScoped<IAudioConverter, FfmpegAudioConverter>();
            services.AddSingleton(new Model(ConfigurationFiles.Vosk));

            return services;
        }

        public static IServiceCollection AddIntentRecognition(
            this IServiceCollection services)
        {
            services.AddScoped<IIntentRecognizerService, IntentRecognizerService>();

            return services;
        }

        public static IServiceCollection AddResponseProviders(
            this IServiceCollection services)
        {
            services.AddScoped<IIntentResponseProvider, BotConfigResponseProvider>();
            services.AddScoped<IFailureResponseProvider, BotConfigFailureResponseProvider>();
            services.AddScoped<IInputResponseProvider, InputResponseProvider>();
            services.AddScoped<IJsonDataProvider<BotConfig>, IntentJsonDataProvider<BotConfig>>();

            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IDialoguesRepository, DialoguesRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();

            return services;
        }

        public static IServiceCollection AddRandom(
            this IServiceCollection services)
        {
            services.AddScoped<Random>();

            return services;
        }

        public static IServiceCollection AddMachineLearning(this IServiceCollection services)
        {
            services.AddScoped<ITrainer<IntentData>, IntentTrainer>();
            services.AddScoped<IClassifier<IntentData, IntentPrediction>, IntentClassifier>();
            services.AddScoped<MLContext>();

            services.AddPredictionEnginePool<IntentData, IntentPrediction>()
                .FromFile(
                    modelName: MLModel.Intent,
                    filePath: ConfigurationFiles.Model,
                    watchForChanges: true
                );

            return services;
        }

        public static IServiceCollection AddAdvertisement(
            this IServiceCollection services)
        {
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IBookLinkService, BookLinkService>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }

        public static IServiceCollection AddDialogue(
            this IServiceCollection services)
        {
            services.AddScoped<IDialogueService, DialogueService>();

            return services;
        }

        public static IServiceCollection AddCommand(
            this IServiceCollection services)
        {
            services.AddScoped<ICommandExecutor, CommandExecutor>();
            services.AddScoped<ICommand, StartCommand>();
            services.AddScoped<ICommand, HelpCommand>();
            services.AddScoped<ICommand, DefaultCommand>();
            services.AddScoped<ICommand, VoiceCommand>();

            return services;
        }

        public static IServiceCollection AddFile(
            this IServiceCollection services, string path)
        {
            services.AddScoped<IFileResponse, FileResponse>(sp =>
                new FileResponse(
                    path: path,
                    preprocessor: sp.GetRequiredService<ITextPreprocessor>()));

            services.AddScoped<IFileResponseProvider, FileResponseProvider>(sp =>
                new FileResponseProvider(
                    path: path,
                    preprocessor: sp.GetRequiredService<ITextPreprocessor>()));

            return services;
        }
    }
}
