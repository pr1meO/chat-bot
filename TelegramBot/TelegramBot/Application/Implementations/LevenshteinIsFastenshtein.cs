using Fastenshtein;
using TelegramBot.Application.Interfaces;

namespace TelegramBot.Application.Implementations
{
    public class LevenshteinIsFastenshtein : ILevenshtein
    {
        public int Distance(string value1, string value2)
        {
            return Levenshtein.Distance(value1, value2);
        }
    }
}
