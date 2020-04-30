using System;
using Microsoft.ML.Data;

namespace Bot.Builder.Community.Recognizers.ML.Models
{
    public class Intent
    {
        [LoadColumn(0)]
        public string Name;

        [LoadColumn(1)]
        public string Utterance; // This is an issue label, for example "area-System.Threading"
    }
}
