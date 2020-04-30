using Microsoft.ML;

namespace Bot.Builder.Community.Recognizers.ML
{
    public interface IMLModelEngine<TData, TPrediction>
        where TData : class
        where TPrediction : class, new()
    {
        ITransformer MLModel { get; }

        void BuildAndTrainModel(string DataSetLocation);

        TPrediction Predict(TData dataSample);
    }
}