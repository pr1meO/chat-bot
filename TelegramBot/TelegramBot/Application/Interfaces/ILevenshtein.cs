namespace TelegramBot.Application.Interfaces
{
    public interface ILevenshtein
    {
        int Distance(string value1, string value2);
    }
}
