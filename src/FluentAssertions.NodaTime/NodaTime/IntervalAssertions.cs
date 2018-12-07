using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class IntervalAssertions : ReferenceTypeAssertions<Interval, IntervalAssertions>
    {
        protected override string Identifier => throw new System.NotImplementedException();
    }
}