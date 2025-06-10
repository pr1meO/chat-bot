using TelegramBot.Application.Interfaces.MachineLearning;

namespace TelegramBot.Application.DTOs
{
    public class IntentData : IData
    {
        public string Text { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
}
