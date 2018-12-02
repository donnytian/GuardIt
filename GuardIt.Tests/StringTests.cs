using System;
using Shouldly;
using Xunit;

namespace GuardIt.Tests
{
    public class StringTests
    {
        [Theory]
        [InlineData("dummy")]
        [InlineData(" ")]
        public void NotNullOrEmptyArg_WhenNotEmpty_ReturnsSelf(string it)
        {
            // Arrange, Act
            var result = it.NotNullOrEmptyArg(nameof(it));

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotNullOrEmptyArg_WhenNullOrEmpty_ThrowsArgumentException(string it)
        {
            // Arrange
            const string message = "custom message";

            // Act, Assert
            Should.Throw<ArgumentException>(() => it.NotNullOrEmptyArg(nameof(it), message))
                .Message.ShouldContain(message);
        }

        [Theory]
        [InlineData("dummy")]
        [InlineData(" d ")]
        public void NotNullOrWhiteSpaceArg_WhenNotNullOrWhiteSpace_ReturnsSelf(string it)
        {
            // Arrange, Act
            var result = it.NotNullOrWhiteSpaceArg(nameof(it));

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void NotNullOrWhiteSpaceArg_WhenNullOrWhiteSpace_ThrowsArgumentException(string it)
        {
            // Arrange
            const string message = "custom message";

            // Act, Assert
            Should.Throw<ArgumentException>(() => it.NotNullOrWhiteSpaceArg(nameof(it), message))
                .Message.ShouldContain(message);
        }

        [Theory]
        [InlineData("dummy")]
        [InlineData("  ")]
        public void InvalidOperationIfNullOrEmpty_WhenNotNullOrEmpty_ReturnsSelf(string it)
        {
            // Arrange, Act
            var result = it.InvalidOperationIfNullOrEmpty(nameof(it));

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void InvalidOperationIfNullOrEmpty_WhenNullOrEmpty_ThrowsInvalidOperationException(string it)
        {
            // Arrange
            var innerException = new Exception();
            const string message = "custom message";

            // Act, Assert
            var exception = Should.Throw<InvalidOperationException>(() => it.InvalidOperationIfNullOrEmpty(message, innerException));
            exception.Message.ShouldBe(message);
            exception.InnerException.ShouldBeSameAs(innerException);
        }

        [Theory]
        [InlineData("dummy")]
        [InlineData(" d ")]
        public void InvalidOperationIfNullOrWhiteSpace_WhenNotNullOrWhiteSpace_ReturnsSelf(string it)
        {
            // Arrange, Act
            var result = it.InvalidOperationIfNullOrWhiteSpace(nameof(it));

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void InvalidOperationIfNullOrWhiteSpace_WhenNullOrWhiteSpace_ThrowsInvalidOperationException(string it)
        {
            // Arrange
            var innerException = new Exception();
            const string message = "custom message";

            // Act, Assert
            var exception = Should.Throw<InvalidOperationException>(() => it.InvalidOperationIfNullOrWhiteSpace(message, innerException));
            exception.Message.ShouldBe(message);
            exception.InnerException.ShouldBeSameAs(innerException);
        }
    }
}
