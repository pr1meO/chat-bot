namespace TelegramBot.Application.Interfaces.Speech
{
    public interface ISpeechSynthesize
    {
        Stream Synthesize(string replica);
    }
}
