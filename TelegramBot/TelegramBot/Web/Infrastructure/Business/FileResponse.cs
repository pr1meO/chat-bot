using System.Collections.ObjectModel;
using TelegramBot.Application.Interfaces;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Domain.Exceptions;
using TelegramBot.Domain.Interfaces;
using TelegramBot.Shared.Messages;

namespace TelegramBot.Web.Infrastructure.Business
{
    public class FileResponse : IFileResponse
    {
        private readonly string _path;
        private readonly ITextPreprocessor _preprocessor;

        public FileResponse(
            string path,
            ITextPreprocessor preprocessor)
        {
            _path = path;
            _preprocessor = preprocessor;
        }

        public async Task<IEnumerable<T>> ReadAsync<T>()
            where T : IDialogue, new()
        {
            string? line = null;
            string? question = null;

            var dialogues = new Collection<T>();

            using var reader = new StreamReader(_path);

            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    question = null;
                    continue;
                }

                if (question is not null)
                {
                    dialogues.Add(new T()
                    {
                        Id = Guid.NewGuid(),
                        Question = question,
                        Answer = line,
                        Length = question.Length
                    });
                    question = null;
                    continue;
                }

                question = _preprocessor.Preprocess(line);
            }

            if (dialogues.Count == 0)
                throw new FileEmptyException(FileExceptionMessages.Empty);

            return dialogues;
        }
    }
}
