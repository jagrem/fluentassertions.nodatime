using System;
using NodaTime;
using NUnit.Framework;
using FluentAssertions;

namespace FluentAssertions.NodaTime.Tests
{
    public class DurationAssertionsTests
    {
        [Test]
        public void When_comparing_durations_Then_the_correct_extensions_are_invoked()
        {
            // Act
            var assertions = Duration.FromDays(1).Should();

            // Assert
            assertions
                .Should()
                .BeOfType<DurationAssertions>();
        }

        [Test]
        public void Given_two_equal_durations_When_asserting_they_are_equal_Then_the_assertion_passes()
        {
            // Act
            Action act = () => Duration.FromDays(2).Should().Be(Duration.FromDays(2));

            // Assert
            act
                .Should()
                .NotThrow();
        }

        [TestCase(null, null, "Expected duration to be 4:00:00:00, but found 3:00:00:00.")]
        [TestCase("the answer should be {0}", "42", "Expected duration to be 4:00:00:00 because the answer should be 42, but found 3:00:00:00.")]
        public void Given_two_different_durations_When_asserting_they_are_equal_Then_the_assertion_fails(string because, string becauseArgs, string expected)
        {
            // Act
            Action act = () => Duration.FromDays(3).Should().Be(Duration.FromDays(4), because, becauseArgs);

            // Assert
            act
                .Should()
                .Throw<AssertionException>()
                .WithMessage(expected);
        }

        [TestCase(null, null, "Expected duration to be 5:00:00:00, but found 5:00:00:00.")]
        [TestCase("the answer should be {0}", "42", "Expected duration to be 5:00:00:00 because the answer should be 42, but found 5:00:00:00.")]
        public void Given_two_equal_durations_When_asserting_they_are_not_equal_Then_the_assertion_fails(string because, string becauseArgs, string expected)
        {
            // Act
            Action act = () => Duration.FromDays(5).Should().NotBe(Duration.FromDays(5), because, becauseArgs);

            // Assert
            act
                .Should()
                .Throw<AssertionException>()
                .WithMessage(expected);
        }

        [Test]
        public void Given_two_different_durations_When_asserting_they_are_not_equal_Then_the_assertion_passes()
        {
            // Act
            Action act = () => Duration.FromDays(6).Should().NotBe(Duration.FromDays(7));

            // Assert
            act
                .Should()
                .NotThrow();
        }

        [Test]
        public void Given_a_positive_duration_When_asserting_it_is_positive_Then_the_assertion_fails()
        {
            // Act
            Action act = () => Duration.FromDays(8).Should().BePositive();

            // Assert
            act
                .Should()
                .NotThrow();
        }

        [TestCase(null, null, "Expected duration to be positive, but found -9:00:00:00.")]
        [TestCase("the answer should be {0}", "42", "Expected duration to be positive because the answer should be 42, but found -9:00:00:00.")]
        public void Given_a_negative_duration_When_asserting_it_is_positive_Then_the_assertion_fails(string because, string becauseArgs, string expected)
        {
            // Act
            Action act = () => Duration.Negate(Duration.FromDays(9)).Should().BePositive(because, becauseArgs);

            // Assert
            act
                .Should()
                .Throw<AssertionException>()
                .WithMessage(expected);
        }
    }
}
