using System;
using Antlr4.Runtime;

namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    public static class Extensions
    {
        /// <summary>
        /// Convert antlr parser into Range.
        /// </summary>
        /// <param name="context">Antlr parse context.</param>
        /// <param name="lineOffset">Line offset.</param>
        /// <returns>Range object.</returns>
        public static Range ConvertToRange(this ParserRuleContext context, int lineOffset = 0)
        {
            if (context == null)
            {
                return Range.DefaultRange;
            }

            var startPosition = new Position(lineOffset + context.Start.Line, context.Start.Column);
            var stopPosition = new Position(lineOffset + context.Stop.Line, context.Stop.Column + context.Stop.Text.Length);
            return new Range(startPosition, stopPosition);
        }
    }
}
