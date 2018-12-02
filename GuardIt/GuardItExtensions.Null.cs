using System;
using System.Diagnostics;

namespace GuardIt
{
    public static partial class GuardItExtensions
    {
        private const string InvalidOperationDefaultMessage = "Invalid operation due to the null value.";

        [DebuggerStepThrough]
        public static T NotNullArg<T>(this T it, string paramName, string message = default)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentException("paramName cannot be null or space.");
            }

            if (it == null)
            {
                throw message == null
                    ? new ArgumentNullException(paramName)
                    : new ArgumentNullException(paramName, message);
            }

            return it;
        }

        [DebuggerStepThrough]
        public static T NotNullArg<T>(this T? it, string paramName, string message = default)
            where T : struct 
        {
            if (string.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentException("paramName cannot be null or space.");
            }

            if (it == null)
            {
                throw message == null
                    ? new ArgumentNullException(paramName)
                    : new ArgumentNullException(paramName, message);
            }

            return it.Value;
        }

        [DebuggerStepThrough]
        public static T InvalidOperationIfNull<T>(this T it, string message = default, Exception innerException = default)
            where T : class
        {
            if (it == null)
            {
                var errorMessage = message ?? InvalidOperationDefaultMessage;
                throw innerException == null
                    ? new InvalidOperationException(errorMessage)
                    : new InvalidOperationException(message, innerException);
            }

            return it;
        }

        [DebuggerStepThrough]
        public static T InvalidOperationIfNull<T>(this T? it, string message = default, Exception innerException = default)
            where T : struct
        {
            if (it == null)
            {
                var errorMessage = message ?? InvalidOperationDefaultMessage;
                throw innerException == null
                    ? new InvalidOperationException(errorMessage)
                    : new InvalidOperationException(message, innerException);
            }

            return it.Value;
        }
    }
}
