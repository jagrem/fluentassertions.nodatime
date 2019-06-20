using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeCloseToTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_two_durations_that_differ_by_more_than_the_given_precision_and_no_reason_When_asserting_is_close_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromMinutes(1)))
                .Should().Throw<AssertionException>().WithMessage($"Expected duration to be close to {expected}:00:00:00 with a precision of 0:00:01:00, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_two_durations_that_differ_by_more_than_the_given_precision_When_asserting_is_close_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromMinutes(1), because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage($"Expected duration to be close to {expected}:00:00:00 with a precision of 0:00:01:00 because the answer should be 42, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_two_durations_that_differ_by_less_than_the_given_precision_and_no_reason_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(actual * 2));

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.GreaterThan))]
        public void Given_two_durations_that_differ_by_less_than_the_given_precision_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(actual * 2), because, becauseArgs);

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_and_no_reason_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1));

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1), because, becauseArgs);
    }
}
