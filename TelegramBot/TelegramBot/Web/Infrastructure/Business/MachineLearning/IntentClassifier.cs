using Microsoft.Extensions.ML;
using TelegramBot.Application.DTOs;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.MachineLearning
{
    public class IntentClassifier : IClassifier<IntentData, IntentPrediction>
    {
        private readonly PredictionEnginePool<IntentData, IntentPrediction> _prediction;

        public IntentClassifier(PredictionEnginePool<IntentData, IntentPrediction> prediction)
        {
            _prediction = prediction;
        }

        public string Predict(string text)
        {
            var predict = _prediction.Predict(
                MLModel.Intent,
                new IntentData
                {
                    Text = text
                });

            return predict.Label;
        }
    }
}
