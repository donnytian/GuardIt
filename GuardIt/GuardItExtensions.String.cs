using System;
using System.Diagnostics;

namespace GuardIt
{
    public static partial class GuardItExtensions
    {
        private const string NullOrEmptyDefaultMessage = "Value cannot be null or empty.";
        private const string NullOrWhiteSpaceDefaultMessage = "Value cannot be null or white space.";

        [DebuggerStepThrough]
        public static string NotNullOrEmptyArg(this string it, string paramName, string message = default)
        {
            if (string.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentException("paramName cannot be null or space.");
            }

            if (!string.IsNullOrEmpty(it))
            {
                return it;
            }

            throw new ArgumentException(message ?? NullOrEmptyDefaultMessage, paramName);
        }

        [DebuggerStepThrough]
        public static string NotNullOrWhiteSpaceArg(this string it, string paramName, string message = default)
        {
            if (string.IsNullOrWhiteSpace(paramName))
            {
                throw new ArgumentException("paramName cannot be null or space.");
            }

            if (!string.IsNullOrWhiteSpace(it))
            {
                return it;
            }

            throw new ArgumentException(message ?? NullOrWhiteSpaceDefaultMessage, paramName);
        }

        [DebuggerStepThrough]
        public static string InvalidOperationIfNullOrEmpty(this string it, string message = default, Exception innerException = default)
        {
            if (!string.IsNullOrEmpty(it))
            {
                return it;
            }

            var errorMessage = message ?? NullOrEmptyDefaultMessage;
            throw innerException == null
                ? new InvalidOperationException(errorMessage)
                : new InvalidOperationException(message, innerException);
        }

        [DebuggerStepThrough]
        public static string InvalidOperationIfNullOrWhiteSpace(this string it, string message = default, Exception innerException = default)
        {
            if (!string.IsNullOrWhiteSpace(it))
            {
                return it;
            }

            var errorMessage = message ?? NullOrWhiteSpaceDefaultMessage;
            throw innerException == null
                ? new InvalidOperationException(errorMessage)
                : new InvalidOperationException(message, innerException);
        }
    }
}
