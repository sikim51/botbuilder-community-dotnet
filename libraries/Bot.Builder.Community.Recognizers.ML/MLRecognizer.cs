using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Recognizers.ML.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace Bot.Builder.Community.Recognizers.ML
{
    public class MLRecognizer : Recognizer
    {
        [JsonProperty("$kind")]
        public const string Kind = "Community.MLRecognizer";

        [JsonConstructor]
        public MLRecognizer()
        {
        }

        public async override Task<RecognizerResult> RecognizeAsync(DialogContext dialogContext, Activity activity, CancellationToken cancellationToken = default, Dictionary<string, string> telemetryProperties = null, Dictionary<string, double> telemetryMetrics = null)
        {

            // Identify matched intents
            var recognizerResult = new RecognizerResult()
            {
                Text = activity.Text,
                Intents = new Dictionary<string, IntentScore>(),
            };

            if (string.IsNullOrEmpty(activity.Text))
            {
                recognizerResult.Intents.Add("None", new IntentScore());
                return recognizerResult;
            }

            var mlModelEngine = dialogContext.Context.TurnState.Get<IMLModelEngine<Intent, IntentPrediction>>();

            var utterance = new Intent() { Utterance = activity.Text };
            var predictions = mlModelEngine.Predict(utterance);

            recognizerResult.Intents.Add(predictions.Name, new IntentScore() { Score = predictions.Score[0] });

            return recognizerResult;
        }
    }
}
