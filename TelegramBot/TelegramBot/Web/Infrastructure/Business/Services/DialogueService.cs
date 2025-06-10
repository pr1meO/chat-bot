using TelegramBot.Application.DTOs;
using TelegramBot.Application.Interfaces;
using TelegramBot.Application.Interfaces.Services;
using TelegramBot.Domain.Entities;
using TelegramBot.Domain.Interfaces.Repositories;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Web.Infrastructure.Business.Services
{
    public class DialogueService : IDialogueService
    {
        private readonly IFileResponse _response;
        private readonly IDialoguesRepository _dialoguesRepository;
        private readonly ILevenshtein _levenshtein;

        public DialogueService(
            IFileResponse response,
            IDialoguesRepository dialoguesRepository,
            ILevenshtein levenshtein)
        {
            _response = response;
            _dialoguesRepository = dialoguesRepository;
            _levenshtein = levenshtein;
        }

        public async Task SeedAsync()
        {
            if (await _dialoguesRepository.ExistsAsync())
                return;

            var dialogues = await _response.ReadAsync<Dialogue>();

            await _dialoguesRepository.AddRangeAsync(dialogues);
        }

        public async Task<string?> MatchAsync(string input)
        {
            var dialogues = await _dialoguesRepository.GetByLengthAsync(input.Length, MatchingConstants.Tolerance);

            if (!dialogues.Any())
                return null;

            var matchResult = dialogues
                .Select(d =>
                {
                    var length = input.Length;
                    var maxLength = Math.Max(length, d.Question.Length);

                    return new MatchResult()
                    {
                        Answer = d.Answer,
                        Weight = _levenshtein.Distance(d.Question, input) / (double)maxLength
                    };
                })
                .OrderBy(d => d.Weight)
                .FirstOrDefault(d => d.Weight < MatchingConstants.Distance);

            return matchResult?.Answer;
        }
    }
}
