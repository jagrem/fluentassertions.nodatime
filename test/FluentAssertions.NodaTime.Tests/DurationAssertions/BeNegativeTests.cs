using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BeNegativeTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [Test]
        public void Given_a_negative_duration_and_no_reason_When_asserting_it_is_negative_Then_the_assertion_passes() =>
            Duration.FromDays(-8).Should().BeNegative(null, null);

        [Test]
        public void Given_a_negative_duration_When_asserting_it_is_negative_Then_the_assertion_passes() =>
            Duration.FromDays(-8).Should().BeNegative(because, becauseArgs);

        [Test]
        public void Given_a_zero_duration_and_no_reason_When_asserting_it_is_negative_Then_the_assertion_fails() =>
            new Action(() => Duration.Zero.Should().BeNegative(null, null))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be negative, but found 0:00:00:00.");

        [Test]
        public void Given_a_zero_duration_When_asserting_it_is_negative_Then_the_assertion_fails() =>
            new Action(() => Duration.Zero.Should().BeNegative(because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be negative because the answer should be 42, but found 0:00:00:00.");

        [Test]
        public void Given_a_positive_duration_and_no_reason_When_asserting_it_is_negative_Then_the_assertion_fails() =>
            new Action(() => Duration.FromDays(8).Should().BeNegative(null, null))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be negative, but found 8:00:00:00.");

        [Test]
        public void Given_a_positive_duration_When_asserting_it_is_negative_Then_the_assertion_fails() =>
            new Action(() => Duration.FromDays(8).Should().BeNegative(because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage("Expected duration to be negative because the answer should be 42, but found 8:00:00:00.");
    }
}
