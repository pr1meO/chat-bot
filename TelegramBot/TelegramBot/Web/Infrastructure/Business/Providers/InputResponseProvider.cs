using TelegramBot.Application.Interfaces.Providers;
using TelegramBot.Application.Interfaces.Services;

namespace TelegramBot.Web.Infrastructure.Business.Providers
{
    public class InputResponseProvider : IInputResponseProvider
    {
        private readonly IDialogueService _dialogueService;

        public InputResponseProvider(IDialogueService dialogueService)
        {
            _dialogueService = dialogueService;
        }

        public async Task<string?> GetAsync(string input)
        {
            var response = await _dialogueService.MatchAsync(input);

            return response;
        }
    }
}