using Microsoft.ML;

namespace TelegramBot.Application.Interfaces.MachineLearning
{
    public interface ITrainer<TSrc>
        where TSrc : class, IData
    {
        (ITransformer Model, DataViewSchema Schema) Train();
    }
}
