using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class BePositiveTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [Test]
        public void Given_a_positive_duration_and_no_reason_When_asserting_it_is_positive_Then_the_assertion_passes() =>
            Duration.FromDays(8).Should().BePositive(null, null);

        [Test]
        public void Given_a_positive_duration_When_asserting_it_is_positive_Then_the_assertion_passes() =>
            Duration.FromDays(8).Should().BePositive(because, becauseArgs);

        [Test]
        public void Given_a_zero_duration_When_asserting_it_is_positive_Then_the_assertion_passes() =>
            Duration.Zero.Should().BePositive(because, becauseArgs);

        [Test]
        public void Given_a_zero_duration_and_no_reason_When_asserting_it_is_positive_Then_the_assertion_passes() =>
            Duration.Zero.Should().BePositive(null, null);

        [Test]
        public void Given_a_negative_duration_and_no_reason_When_asserting_it_is_positive_Then_the_assertion_fails() =>
            new Action(() => Duration.FromDays(-8).Should().BePositive(null, null))
                .Should().Throw<AssertionException>().WithMessage("Expected a positive duration but found 00:00:00.");

        [Test]
        public void Given_a_negative_duration_When_asserting_it_is_positive_Then_the_assertion_fails() =>
            new Action(() => Duration.FromDays(-8).Should().BePositive(because, becauseArgs))
                .Should().Throw<AssertionException>().WithMessage("Expected a positive duration because the answer is 42 but found 00:00:00.");
    }
}
