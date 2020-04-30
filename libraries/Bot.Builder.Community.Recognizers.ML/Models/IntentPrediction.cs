using System;
using Microsoft.ML.Data;

namespace Bot.Builder.Community.Recognizers.ML.Models
{
    public class IntentPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Name;

        public float[] Score;
    }
}
