using NUnit.Framework;
using FluentAssertions;
using NodaTime;
using System;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [Test]
        public void Given_two_equal_durations_and_no_reason_When_asserting_they_are_equal_Then_the_assertion_passes() =>
            Duration.FromDays(1).Should().Be(Duration.FromDays(1), null, null);

        [Test]
        public void Given_two_equal_durations_When_asserting_they_are_equal_Then_the_assertion_passes() =>
            Duration.FromDays(2).Should().Be(Duration.FromDays(2), because, becauseArgs);

        [Test]
        public void Given_two_different_durations_When_asserting_they_are_equal_Then_the_assertion_fails_with_the_expected_message() =>
            new Action(() => Duration.FromDays(3).Should().Be(Duration.FromDays(4), because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be 4:00:00:00 because the answer should be 42, but found 3:00:00:00.");

        [Test]
        public void Given_two_different_durations_and_no_reason_When_asserting_they_are_equal_Then_the_assertion_fails_with_the_expected_message() =>
            new Action(() => Duration.FromDays(5).Should().Be(Duration.FromDays(6), null, null))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be 6:00:00:00, but found 5:00:00:00.");
    }
}
