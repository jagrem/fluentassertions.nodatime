using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class DurationAssertions
    {
        public DurationAssertions(Duration? value) => Subject = value;

        public Duration? Subject { get; }

        AndConstraint<DurationAssertions> ExecuteAssertion(bool condition, Duration expected, string because = null, params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(condition)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:duration} to be {0}{reason}, but found {1}.",
                    expected,
                    Subject ?? default(Duration?));

            return new AndConstraint<DurationAssertions>(this);
        }

        public AndConstraint<DurationAssertions> Be(Duration expected, string because = "", params object[] becauseArgs) =>
            ExecuteAssertion(Subject.HasValue && (Subject.Value == expected), expected, because, becauseArgs);

        public AndConstraint<DurationAssertions> NotBe(Duration expected, string because = "", params object[] becauseArgs) =>
            ExecuteAssertion(!Subject.HasValue || Subject.Value != expected, expected, because, becauseArgs);

        public AndConstraint<DurationAssertions> BePositive(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.Value.CompareTo(Duration.Zero) > 0)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:duration} to be positive{reason}, but found {0}.", Subject.Value);

            return new AndConstraint<DurationAssertions>(this);
        }

        public AndConstraint<DurationAssertions> BeNegative(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.Value.CompareTo(Duration.Zero) < 0)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:duration} to be negative{reason}, but found {0}.", Subject.Value);

            return new AndConstraint<DurationAssertions>(this);
        }

        public AndConstraint<SimpleTimeSpanAssertions> BeLessThan(Duration expected, string because = "", params object[] becauseArgs)
        {
            throw new NotImplementedException();
        }

        public AndConstraint<SimpleTimeSpanAssertions> BeLessOrEqualTo(Duration expected, string because = "", params object[] becauseArgs)
        {
            throw new NotImplementedException();
        }

        public AndConstraint<SimpleTimeSpanAssertions> BeGreaterThan(Duration expected, string because = "", params object[] becauseArgs)
        {
            throw new NotImplementedException();
        }

        public AndConstraint<SimpleTimeSpanAssertions> BeGreaterOrEqualTo(Duration expected, string because = "", params object[] becauseArgs)
        {
            throw new NotImplementedException();
        }

        public AndConstraint<SimpleTimeSpanAssertions> BeCloseTo(Duration nearbyTime, Duration precision, string because = "",
            params object[] becauseArgs)
        {
            throw new NotImplementedException();
        }
    }
}
