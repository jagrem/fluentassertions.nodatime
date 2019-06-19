using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeCloseToTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_two_durations_that_differ_by_more_than_the_given_precision_and_no_reason_When_asserting_is_close_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromMinutes(1), null, null))
                .Should().Throw<AssertionException>().WithMessage("Expected ...");

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_two_durations_that_differ_by_more_than_the_given_precision_When_asserting_is_close_to_Then_the_assertion_fails(int actual, int expected) =>
            new Action(() => Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromMinutes(1), because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage("Expected ...");

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_two_durations_that_differ_by_less_than_the_given_precision_and_no_reason_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1), null, null);

        [TestCaseSource(nameof(EqualityTestCases.GetLongAndShortDurations))]
        public void Given_two_durations_that_differ_by_less_than_the_given_precision_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1), because, becauseArgs);

        [TestCaseSource(nameof(EqualityTestCases.GetEqualDurations))]
        public void Given_two_equal_durations_and_no_reason_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1), null, null);

        [TestCaseSource(nameof(EqualityTestCases.GetEqualDurations))]
        public void Given_two_equal_durations_When_asserting_is_close_to_Then_the_assertion_passes(int actual, int expected) =>
            Duration.FromDays(actual).Should().BeCloseTo(Duration.FromDays(expected), Duration.FromDays(1), because, becauseArgs);
    }
}
