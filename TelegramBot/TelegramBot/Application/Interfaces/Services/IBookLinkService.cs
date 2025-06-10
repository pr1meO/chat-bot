namespace TelegramBot.Application.Interfaces.Services
{
    public interface IBookLinkService
    {
        Uri Generate(string link);
    }
}
