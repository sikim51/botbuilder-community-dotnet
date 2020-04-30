﻿namespace Bot.Builder.Community.Recognizers.ML.Lu
{
    /// <summary>
    /// Represents the severity of diagnostics.
    /// </summary>
    public enum DiagnosticSeverity
    {
        /// <summary>
        /// Catch Error info.
        /// </summary>
        Error,

        /// <summary>
        /// Catch Warning info.
        /// </summary>
        Warning,

        /// <summary>
        /// Something to inform about but not a problem.
        /// </summary>
        Information,

        /// <summary>
        /// Something to hint to a better way of doing it, like proposing
        /// a refactoring.
        /// </summary>
        Hint,
    }

    /// <summary>
    /// Error/Warning report when parsing/evaluating template/inlineText.
    /// </summary>
    public class Diagnostic
    {
        public Diagnostic(
            Range range,
            string message,
            DiagnosticSeverity severity = DiagnosticSeverity.Error,
            string source = null,
            string code = null)
        {
            Message = message;
            Range = range;
            Severity = severity;
            Source = source;
            Code = code;
        }

        /// <summary>
        ///  Gets or sets a code or identifier for this diagnostics.
        /// </summary>
        /// <value>
        /// A code or identifier for this diagnostics.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        ///  Gets or sets the range to which this diagnostic applies.
        /// </summary>
        /// <value>
        /// The range to which this diagnostic applies.
        /// </value>
        public Range Range { get; set; }

        /// <summary>
        /// Gets or sets the severity, default is <see cref="DiagnosticSeverity.Error"/>.
        /// </summary>
        /// <value>
        /// The severity, default is <see cref="DiagnosticSeverity.Error"/>.
        /// </value>
        public DiagnosticSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets a human-readable string describing the source of this diagnostic.
        /// </summary>
        /// <value>
        /// A human-readable string describing the source.
        /// </value>
        public string Source { get; set; }

        /// <summary>
        /// Gets the human-readable message.
        /// </summary>
        /// <value>
        /// The human-readable message.
        /// </value>
        public string Message { get; }

        public override string ToString()
        {
            return $"[{Severity}] {Range}: {Message}";
        }
    }
}