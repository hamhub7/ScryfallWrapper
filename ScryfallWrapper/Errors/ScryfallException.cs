using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Errors
{
    public class ScryfallException : Exception
    {
        /// <summary>
        /// An integer HTTP status code for this error.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// A computer-friendly string representing the appropriate HTTP status code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// A human-readable string explaining the error.
        /// </summary>
        public string Details { get; }

        /// <summary>
        /// A computer-friendly string that provides additional context for the main error. For example, an endpoint many generate HTTP 404 errors for different kinds of input. This field will provide a label for the specific kind of 404 failure, such as ambiguous.
        /// </summary>
        public string? Type { get; }

        /// <summary>
        /// If your input also generated non-failure warnings, they will be provided as human-readable strings in this array.
        /// </summary>
        public string[]? Warnings { get; }

        public ScryfallException(int status, string code, string details) : base(details)
        {
            Status = status;
            Code = code;
            Details = details;
        }

        public ScryfallException(int status, string code, string details, string? type) : this(status, code, details)
        {
            Type = type;
        }

        public ScryfallException(int status, string code, string details, string? type, string[]? warnings) : this(status, code, details, type)
        {
            Warnings = warnings;
        }
    }
}
