namespace TelegramBot.Application.Interfaces.Speech
{
    public interface IAudioConverter
    {
        Task<MemoryStream> ConvertToWavAsync(Stream inStream);
    }
}
