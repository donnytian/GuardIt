using System;
using Shouldly;
using Xunit;

namespace GuardIt.Tests
{
    public class ReferenceTypeTests
    {
        [Fact]
        public void NotNullArg_WhenNotNull_ReturnsSelf()
        {
            // Arrange
            var it = new object();

            // Act
            var result = it.NotNullArg(nameof(it));

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Fact]
        public void NotNullArg_WhenNull_ThrowsArgumentNullException()
        {
            // Arrange
            object it = null;
            const string message = "custom message";

            // Act, Assert
            Should.Throw<ArgumentNullException>(() => it.NotNullArg(nameof(it), message))
                .Message.ShouldContain(message);
        }

        [Fact]
        public void InvalidOperationIfNull_WhenNotNull_ReturnsSelf()
        {
            // Arrange
            var it = new object();

            // Act
            var result = it.InvalidOperationIfNull();

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Fact]
        public void InvalidOperationIfNull_WhenNull_ThrowsInvalidOperationException()
        {
            // Arrange
            object it = null;
            var innerException = new Exception();
            const string message = "custom message";

            // Act, Assert
            var exception = Should.Throw<InvalidOperationException>(() => it.InvalidOperationIfNull(message, innerException));
            exception.Message.ShouldBe(message);
            exception.InnerException.ShouldBeSameAs(innerException);
        }

        [Fact]
        public void ThrowIf_WhenConditionIsFalse_ReturnsSelf()
        {
            // Arrange
            var it = new object();

            // Act
            var result = it.ThrowIf(i => false);

            // Assert
            result.ShouldBeSameAs(it);
        }

        [Fact]
        public void ThrowIf_WhenConditionIsTrue_ThrowsException()
        {
            // Arrange
            var it = new object();
            var expected = new Exception();

            // Act, Assert
            var exception = Should.Throw<Exception>(() => it.ThrowIf(i => true, () => expected));
            exception.ShouldBeSameAs(expected);
        }

        [Fact]
        public void InvalidOperationIf_WhenConditionIsFalse_ReturnsSelf()
        {
            // Arrange
            //var it = new object();
            int? it = 11;

            // Act
            var result = it.InvalidOperationIf(i => false);

            // Assert
            result.ShouldBe(it);
        }

        [Fact]
        public void InvalidOperationIf_WhenConditionIsTrue_ThrowsException()
        {
            // Arrange
            var it = new object();
            const string message = "custom message";

            // Act, Assert
            var exception = Should.Throw<Exception>(() => it.InvalidOperationIf(i => true, () => message));
            exception.Message.ShouldBe(message);
        }
    }
}
