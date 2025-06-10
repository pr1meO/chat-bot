using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Domain.Entities
{
    public class Dialogue : IDialogue
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int Length { get; set; }
    }
}
