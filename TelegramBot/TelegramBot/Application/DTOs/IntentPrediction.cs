using Microsoft.ML.Data;
using TelegramBot.Application.Interfaces.MachineLearning;

namespace TelegramBot.Application.DTOs
{
    public class IntentPrediction : IPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Label { get; set; } = string.Empty;
    }
}
