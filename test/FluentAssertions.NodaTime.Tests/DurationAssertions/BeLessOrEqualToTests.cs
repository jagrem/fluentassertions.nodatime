using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeLessOrEqualToTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [TestCaseSource(nameof(EqualityTestCases.GetShortAndLongDurations))]
        public void Given_a_short_and_a_long_duration_and_no_reason_When_asserting_is_less_or_equal_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), null, null);

        [TestCaseSource(nameof(EqualityTestCases.GetShortAndLongDurations))]
        public void Given_a_short_and_a_long_duration_When_asserting_is_less_or_equal_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), because, becauseArgs);

        [TestCaseSource(nameof(EqualityTestCases.GetEqualDurations))]
        public void Given_two_equal_durations_and_no_reason_When_asserting_is_less_or_equal_to_Then_the_assertion_fails(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), null, null);

        [TestCaseSource(nameof(EqualityTestCases.GetEqualDurations))]
        public void Given_two_equal_durations_When_asserting_is_less_or_equal_to_Then_the_assertion_fails(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), because, becauseArgs);

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_a_long_and_a_short_duration_and_no_reason_When_asserting_is_less_or_equal_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), null, null))
            .Should().Throw<AssertionException>().WithMessage("Expected...");

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_a_long_and_a_short_duration_When_asserting_is_less_or_equal_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeLessOrEqualTo(Duration.FromDays(expected), because, becauseArgs))
            .Should().Throw<AssertionException>().WithMessage("Expected...");
    }
}
