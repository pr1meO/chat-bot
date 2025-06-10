using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class BotService : IBotService
    {
        private readonly ITextPreprocessor _preprocessor;
        private readonly IIntentRecognizerService _recognizer;
        private readonly IIntentResponseProvider _intentResponse;
        private readonly IInputResponseProvider _inputResponse;
        private readonly IFailureResponseProvider _failureResponse;
        private readonly IAdvertisementService _advertisement;

        public BotService(
            ITextPreprocessor preprocessor,
            IIntentRecognizerService recognizer,
            IIntentResponseProvider intentResponse,
            IInputResponseProvider inputResponse,
            IFailureResponseProvider failureResponse,
            IAdvertisementService advertisement)
        {
            _preprocessor = preprocessor;
            _recognizer = recognizer;
            _intentResponse = intentResponse;
            _inputResponse = inputResponse;
            _failureResponse = failureResponse;
            _advertisement = advertisement;
        }

        public async Task<string> GetResponseAsync(string replica)
        {
            var cleaned = _preprocessor.Preprocess(replica);

            if (cleaned is null)
                return _failureResponse.Get();

            var intent = _recognizer.Recognize(cleaned);

            var response = _intentResponse.Get(intent);

            if (response is not null)
            {
                if (intent == Intents.Books)
                    return await _advertisement.GetBooksAsync(response);

                return response;
            }

            response = await _inputResponse.GetAsync(cleaned);

            if (response is not null)
                return response;

            return _failureResponse.Get();
        }
    }
}
