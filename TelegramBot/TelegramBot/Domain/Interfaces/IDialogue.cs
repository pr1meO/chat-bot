namespace TelegramBot.Domain.Interfaces
{
    public interface IDialogue
    {
        Guid Id { get; set; }
        string Question { get; set; }
        string Answer { get; set; }
        int Length { get; set; }
    }
}
