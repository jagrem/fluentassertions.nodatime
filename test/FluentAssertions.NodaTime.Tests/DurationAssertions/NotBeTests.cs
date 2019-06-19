using System;
using NodaTime;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public class NotBeTests
    {
        const string because = "the answer should be {0}";
        const string becauseArgs = "42";

        [Test]
        public void Given_two_different_durations_When_asserting_they_are_not_equal_Then_the_assertion_passes() =>
            Duration.FromDays(7).Should().NotBe(Duration.FromDays(8), because, becauseArgs);

        [Test]
        public void Given_two_equal_durations_When_asserting_they_are_not_equal_Then_the_assertion_fails() =>
            new Action(() => Duration.FromDays(8).Should().NotBe(Duration.FromDays(8), because, becauseArgs))
                .Should().Throw<AssertionException>();
    }
}
