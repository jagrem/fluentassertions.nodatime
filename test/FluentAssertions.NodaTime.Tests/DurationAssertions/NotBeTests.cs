using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class NotBeTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.NotEqual))]
        public void Given_two_different_durations_and_no_reason_When_asserting_they_are_not_equal_Then_the_assertion_passes(int expected, int actual) =>
            Duration.FromDays(actual).Should().NotBe(Duration.FromDays(expected));

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.NotEqual))]
        public void Given_two_different_durations_When_asserting_they_are_not_equal_Then_the_assertion_passes(int expected, int actual) =>
            Duration.FromDays(actual).Should().NotBe(Duration.FromDays(expected), because, becauseArgs);

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_and_no_reason_When_asserting_they_are_not_equal_Then_the_assertion_fails(int expected, int actual) =>
            new Action(() => Duration.FromDays(actual).Should().NotBe(Duration.FromDays(expected)))
                .Should().Throw<AssertionException>($"Expected duration to not be equal to {expected}:00:00:00, but found {actual}:00:00:00.");

        [TestCaseSource(typeof(ComparisonTestCases), nameof(ComparisonTestCases.Equal))]
        public void Given_two_equal_durations_When_asserting_they_are_not_equal_Then_the_assertion_fails(int expected, int actual) =>
            new Action(() => Duration.FromDays(actual).Should().NotBe(Duration.FromDays(expected), because, becauseArgs))
                .Should().Throw<AssertionException>($"Expected duration to not be equal to {expected}:00:00:00 because the answer should be 42, but found {actual}:00:00:00.");
    }
}
