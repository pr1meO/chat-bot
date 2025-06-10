using TelegramBot.Application.DTOs;
using TelegramBot.Application.Interfaces.MachineLearning;
using TelegramBot.Application.Interfaces.Services;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class IntentRecognizerService : IIntentRecognizerService
    {
        private readonly IClassifier<IntentData, IntentPrediction> _classifier;

        public IntentRecognizerService(IClassifier<IntentData, IntentPrediction> classifier)
        {
            _classifier = classifier;
        }

        public string Recognize(string replica)
        {
            var predict = _classifier.Predict(replica);

            return predict;
        }
    }
}
