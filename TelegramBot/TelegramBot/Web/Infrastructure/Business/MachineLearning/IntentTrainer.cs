using Microsoft.ML;
using TelegramBot.Application.DTOs;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Web.Infrastructure.Configurations;

namespace TelegramBot.Web.Infrastructure.Business.MachineLearning
{
    public class IntentTrainer : ITrainer<IntentData>
    {
        private readonly MLContext _context;
        private readonly IJsonDataProvider<BotConfig> _provider;

        public IntentTrainer(
            MLContext context,
            IJsonDataProvider<BotConfig> provider)
        {
            _context = context;
            _provider = provider;
        }

        public (ITransformer Model, DataViewSchema Schema) Train()
        {
            var dataView = _context.Data.LoadFromEnumerable(_provider
                .Read((text, label) => new IntentData
                {
                    Text = text,
                    Label = label
                }));

            var pipeline = _context.Transforms.Conversion
                .MapValueToKey("Label")
                .Append(_context.Transforms.Text.FeaturizeText("Features", "Text"))
                .Append(_context.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(_context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(dataView);

            return (model, dataView.Schema);
        }
    }
}
