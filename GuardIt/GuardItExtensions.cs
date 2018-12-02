using System;

namespace GuardIt
{
    public static partial class GuardItExtensions
    {
        public static string DefaultExceptionMessage { get; set; } = "Exception occurred.";
        public static string DefaultInvalidOperationExceptionMessage { get; set; } = "Invalid operation caught.";

        public static T ThrowIf<T>(this T it, Func<T, bool> condition, Func<Exception> exceptionGetter = default)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (condition(it))
            {
                if (exceptionGetter == null)
                {
                    throw new Exception(DefaultExceptionMessage);
                }

                throw exceptionGetter();
            }

            return it;
        }

        public static T InvalidOperationIf<T>(this T it, Func<T, bool> condition, Func<string> message = default)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (condition(it))
            {
                var errorMessage = message?.Invoke();

                throw new InvalidOperationException(errorMessage ?? DefaultInvalidOperationExceptionMessage);
            }

            return it;
        }
    }
}
