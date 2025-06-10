using Nestor;
using TelegramBot.Application.Interfaces;
using TelegramBot.Shared.Constants;

namespace TelegramBot.Application.Implementations
{
    public class LemmatizerIsNestor : ILemmatizer
    {
        private readonly NestorMorph _morph;

        public LemmatizerIsNestor(NestorMorph morph)
        {
            _morph = morph;
        }

        public string Lemmatize(string replica)
        {
            return string.Join(Symbols.Space, _morph.Lemmatize(replica));
        }
    }
}
