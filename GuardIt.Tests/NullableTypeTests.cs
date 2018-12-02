using System;
using Shouldly;
using Xunit;

namespace GuardIt.Tests
{
    public class NullableTypeTests
    {
        [Fact]
        public void NotNullArg_WhenNotNull_ReturnsSelf()
        {
            // Arrange
            int? it = 11111;

            // Act
            var result = it.NotNullArg(nameof(it));

            // Assert
            result.ShouldBe(it.Value);
        }

        [Fact]
        public void NotNullArg_WhenNull_ThrowsArgumentNullException()
        {
            // Arrange
            int? it = null;
            const string message = "custom message";

            // Act, Assert
            Should.Throw<ArgumentNullException>(() => it.NotNullArg(nameof(it), message))
                .Message.ShouldContain(message);
        }

        [Fact]
        public void InvalidOperationIfNull_WhenNotNull_ReturnsSelf()
        {
            // Arrange
            int? it = 11111;

            // Act
            var result = it.InvalidOperationIfNull(nameof(it));

            // Assert
            result.ShouldBe(it.Value);
        }

        [Fact]
        public void InvalidOperationIfNull_WhenNull_ThrowsInvalidOperationException()
        {
            // Arrange
            int? it = null;
            var innerException = new Exception();
            const string message = "custom message";

            // Act, Assert
            var exception = Should.Throw<InvalidOperationException>(() => it.InvalidOperationIfNull(message, innerException));
            exception.Message.ShouldBe(message);
            exception.InnerException.ShouldBeSameAs(innerException);
        }
    }
}
