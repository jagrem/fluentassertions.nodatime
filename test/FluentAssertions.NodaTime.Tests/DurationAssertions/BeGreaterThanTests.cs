using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeGreaterThanTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_a_long_and_a_short_duration_and_no_reason_When_asserting_is_greater_than_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected));

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_a_long_and_a_short_duration_When_asserting_is_greater_than_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected), because, becauseArgs);

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_and_no_reason_When_asserting_is_greater_than_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected)))
            .Should().Throw<AssertionException>().WithMessage($"Expected duration to be greater than {expected}:00:00:00, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_When_asserting_is_greater_than_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected), because, becauseArgs))
            .Should().Throw<AssertionException>().WithMessage($"Expected duration to be greater than {expected}:00:00:00 because the answer should be 42, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.LessThan))]
        public void Given_a_short_and_a_long_duration_and_no_reason_When_asserting_is_greater_than_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected)))
            .Should().Throw<AssertionException>().WithMessage($"Expected duration to be greater than {expected}:00:00:00, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.LessThan))]
        public void Given_a_short_and_a_long_duration_When_asserting_is_greater_than_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeGreaterThan(Duration.FromDays(expected), because, becauseArgs))
            .Should().Throw<AssertionException>().WithMessage($"Expected duration to be greater than {expected}:00:00:00 because the answer should be 42, but found {actual}:00:00:00.");
    }
}
