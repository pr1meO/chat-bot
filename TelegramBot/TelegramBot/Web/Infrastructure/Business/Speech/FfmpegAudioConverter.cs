using System.Diagnostics;
using TelegramBot.Application.Interfaces.Speech;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Speech
{
    public class FfmpegAudioConverter : IAudioConverter
    {
        public async Task<MemoryStream> ConvertToWavAsync(Stream inStream)
        {
            using var process = Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = "-loglevel debug -i pipe:0 -f wav -ar 16000 -ac 1 pipe:1",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            if (process is null)
                throw new InvalidOperationException();

            await inStream.CopyToAsync(process.StandardInput.BaseStream);
            process.StandardInput.Close();

            var outStream = new MemoryStream();

            await process.StandardOutput.BaseStream.CopyToAsync(outStream);
            await process.WaitForExitAsync();

            outStream.Position = StreamPositions.NotHeader;
            return outStream;
        }
    }
}
