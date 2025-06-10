using System.Text.RegularExpressions;
using TelegramBot.Application.Interfaces;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Application.Implementations
{
    public class CleanerIsRegex : ICleaner
    {
        private readonly string _pattern = @"[^a-z\d\p{IsCyrillic}- ]";
        private readonly string _space = @"\s+";

        public string Clean(string replica) => 
            NormalizeSpaces(
                Regex
                    .Replace(replica.ToLower(), _pattern, string.Empty)
                    .Trim(Symbols.Space, Symbols.Dash));

        public string NormalizeSpaces(string replica) => Regex
            .Replace(replica, _space, Symbols.Space.ToString());
    }
}
