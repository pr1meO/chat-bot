namespace TelegramBot.Application.Interfaces.MachineLearning
{
    public interface IClassifier<TSrc, TDst>
        where TSrc : class, IData
        where TDst : class, IPrediction, new()
    {
        string Predict(string replica);
    }
}
